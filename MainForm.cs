using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.IO;
using System.Linq;

namespace ShowFilledLog
{
	/// <summary>
	/// Description of MainForm.
	/// </summary>
	public partial class MainForm : Form
	{
		private string _workPath = @"C:\Work\NalivARM_09\Log";
		private bool[] eventmask;
		private string[] eventmsg = new []
			   {
	"Налив завершен аварийно. Сработал сигнализатор аварийный"                  ,
	"Налив завершен аварийно. Неисправность цепи готовности"                    ,
	"Налив завершен аварийно. Неисправность сигнализатора уровня"               ,
	"Налив завершен аварийно. Истекло время работы без связи"                   ,
	"Налив завершен аварийно. Заземление отсутствует"                           ,
	"Налив завершен аварийно. Ошибка клапана большого прожода"                  ,
	"Налив завершен аварийно. Ошибка клапана малого прохода"                    ,
	"Налив завершен аварийно. Ток сигнализатора уровня меньше минимального"     ,
	"Налив завершен аварийно. Ток сигнализатора уровня больше максимального"    ,
	"Налив завершен аварийно. Ток сигнализатора аварийного меньше минимального" ,
	"Налив завершен аварийно. Ток сигнализатора аварийного больше максимального",
	"Налив завершен аварийно. Нет рабочего положения"                           ,
	"Налив завершен аварийно. Неверные данные налива"                           ,
	"Запуск налива."                                                            ,
	"Налив завершен автоматически"                                              ,
	"Налив завершен оператором АРМ"                                             ,
	"Налив завершен кнопкой \"СТОП\" пульта управления"                         ,
    "Запуск системы"                                                            ,
    "Останов системы"                                                           ,
    "Вход в систему"                                                            ,
    "Выход из системы"                                                          ,
	"Установка соединения"                                                      ,
	"Обрыв соединения"                                                          					
			   };
		private List<string> devices = new List<string>();
		private Dictionary<string, bool> devmask = new Dictionary<string, bool>();
		private DateTime firstDate, lastDate;
		private bool firstDateChecked, lastDateChecked;
		private int tabIndex;
		private MemIniFile mif;
		
		private List<EventItem> _log = new List<EventItem>();
		
		public MainForm()
		{
			InitializeComponent();
			var inifilepath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
			                               "AShSvis","ShowFilledLog");
			if (!Directory.Exists(inifilepath)) Directory.CreateDirectory(inifilepath);
			var inifilename = Path.Combine(inifilepath, "ShowFilledLog.ini");
			mif = new MemIniFile(inifilename);
			_workPath = mif.ReadString("FolderLocation", "WorkPath", "");
			tabIndex = mif.ReadInteger("DateRangeFilter", "TabIndex", 0);
			eventmask = new bool[eventmsg.Length];
			for (var i = 0; i < eventmsg.Length; i++)
			{
				var value = mif.ReadBool("EventMasks", "Event" + i, true);
				eventmask[i] = value;
			}
		}
		
		void MiExitClick(object sender, EventArgs e)
		{
			Close();
		}
		
		void MiLoadClick(object sender, EventArgs e)
		{
			LoadLog(true);
		}
		
        public string WorkPath { get { return _workPath; } }

		void LoadLog(bool filtered = false)
		{
			lvLogView.VirtualListSize = 0;
			_log.Clear();
			devices.Clear();
			if (!Directory.Exists(_workPath))
			{
				return;
			}
			Cursor = Cursors.WaitCursor;
			try
			{
				var files = Directory.GetFiles(_workPath, "*.log");
				var first = DateTime.MaxValue;
				var last = DateTime.MinValue;
				foreach (var filename in files)
				{
					try
					{
	 					var buff = File.ReadAllBytes(filename);
						var shift = 0;
						while (shift < buff.Length)
						{
							UInt16 evnt = BitConverter.ToUInt16(buff, shift);
							shift += sizeof(UInt32);
							Int64 timestampts = BitConverter.ToInt64(buff, shift);
							shift += sizeof(Int64);
							var dt = DateTime.FromFileTime(timestampts);
							UInt32 ntank = BitConverter.ToUInt32(buff, shift);
							shift += sizeof(UInt32);	    
							UInt16 ttank = BitConverter.ToUInt16(buff, shift);
							shift += sizeof(UInt16);	    
							UInt16 theight = BitConverter.ToUInt16(buff, shift);
							shift += sizeof(UInt16);	    
							UInt16 theights = BitConverter.ToUInt16(buff, shift);
							shift += sizeof(UInt16);	    
							UInt16 slevel = BitConverter.ToUInt16(buff, shift);
							shift += sizeof(UInt16);	    
							string devpath = System.Text.Encoding.Default.GetString(buff, shift, 56).Trim('\0');
							shift += 56;	    
							if (!devices.Contains(devpath) && devpath.IndexOf("Стояк ") >= 0)
								devices.Add(devpath);
							if (!filtered)
							{
								if (first > dt) first = dt;
								if (last < dt) last = dt;
							}
							if (evnt >= 0 && evnt < eventmsg.Length)
							{
								if (!filtered ||
								    (!firstDateChecked || dt >= firstDate) &&
								    (!lastDateChecked || dt <= lastDate + new TimeSpan(0, 0, 1)) &&
								    eventmask[evnt] &&
								    (!devmask.ContainsKey(devpath) || devmask[devpath])
								   )
								{
									var logitem = new EventItem
									{
										EventCode = evnt,
										SnapTime = dt,
										Number = ntank,
										Type = ttank,
										Height = theight,
										Meagure = theights > 0,
										Setpoint = slevel,
										DevPath = devpath
									};								
									_log.Add(logitem);
								}
							}
							if (buff.Length - shift < 80) break;
						}
						if (!filtered)
						{
							if (first < DateTime.MaxValue)
							{
								firstDate = first;
								firstDateChecked = true;
							}
							else
								firstDateChecked = false;
							if (last > DateTime.MinValue)
							{
								lastDate = last;
								lastDateChecked = true;
							}
							else
								lastDateChecked = false;
						}
						else
						{
							firstDateChecked = mif.ReadBool("DateRangeFilter", "FirstDateChecked", firstDateChecked);
							firstDate = mif.ReadDateTime("DateRangeFilter", "FirstDate", firstDate);
							lastDateChecked = mif.ReadBool("DateRangeFilter", "LastDateChecked", lastDateChecked);
							lastDate = mif.ReadDateTime("DateRangeFilter", "LastDate", lastDate);
						}
                        _log.Sort((a, b) => Comparison(a, b));
						lvLogView.VirtualListSize = _log.Count;
						foreach (var dev in devices.OrderBy(item => SortFunc(item)))
						{
							if (!devmask.ContainsKey(dev))
							{
								var value = mif.ReadBool("DeviceMasks", dev, true);
								devmask.Add(dev, value);
							}
						}
					}
					catch (Exception)
					{
						continue;
					}
				}			
			}
			finally
			{
				Cursor = Cursors.Default;
			}
		}

        private int Comparison(EventItem a, EventItem b)
        {
            return a.SnapTime > b.SnapTime ? 1 : a.SnapTime < b.SnapTime ? -1 : 0;
        }

        string SortFunc(string item)
		{
			var vals = item.Split(new string[] { "Стояк " }, StringSplitOptions.None);
			var value = vals[vals.Length - 1];
			return value.PadLeft(3);
		}
		
		void LvLogViewRetrieveVirtualItem(object sender, RetrieveVirtualItemEventArgs e)
		{
			var logitem = _log[e.ItemIndex];
			var lvi = new ListViewItem();
			lvi.Text = logitem.SnapTime.ToString("dd-MM-yy");
			lvi.SubItems.Add(logitem.SnapTime.ToString("HH:mm:ss"));
			lvi.SubItems.Add(logitem.DevPath);
			lvi.SubItems.Add(eventmsg[logitem.EventCode]);
			if (logitem.EventCode == 13)
			{
				lvi.SubItems.Add(logitem.Number.ToString("00000000"));
				lvi.SubItems.Add(logitem.Type.ToString("0"));
				lvi.SubItems.Add(logitem.Height.ToString("0"));
				lvi.SubItems.Add(logitem.Meagure ? "Замер" : "Тип");
				lvi.SubItems.Add(logitem.Setpoint.ToString("0"));
			}
			else
			{
				lvi.SubItems.Add("");
				lvi.SubItems.Add("");
				lvi.SubItems.Add("");
				lvi.SubItems.Add("");
				lvi.SubItems.Add("");
			}
			e.Item = lvi;
		}
		
		void BtnUpdateClick(object sender, EventArgs e)
		{
			LoadLog(true);
		}
		
		void BtnTuningFilterClick(object sender, EventArgs e)
		{
			var frm = new TuningFilterForm(tabIndex, eventmsg, eventmask, devmask, 
			                               firstDateChecked, firstDate, lastDateChecked, lastDate);
			if (frm.ShowDialog() == DialogResult.OK)
			{
				frm.UpdateTabIndex(ref tabIndex);
				mif.WriteInteger("DateRangeFilter", "TabIndex", tabIndex);
				frm.UpdateEventsMask(ref eventmask);
				for (var i=0; i < eventmask.Length; i++)
				{
					mif.WriteBool("EventMasks", "Event" + i, eventmask[i]);
				}
				frm.UpdateDevicesMask(ref devmask);
				foreach (var dev in devmask.Keys)
				{
					mif.WriteBool("DeviceMasks", dev, devmask[dev]);
				}				
				frm.UpdateDateRange( ref firstDateChecked, ref firstDate, ref lastDateChecked, ref lastDate);
				mif.WriteBool("DateRangeFilter", "FirstDateChecked", firstDateChecked);
				mif.WriteDateTime("DateRangeFilter", "FirstDate", firstDate);
				mif.WriteBool("DateRangeFilter", "LastDateChecked", lastDateChecked);
				mif.WriteDateTime("DateRangeFilter", "LastDate", lastDate);
				mif.UpdateFile();
				LoadLog(true);
			}
		}

        private void miExport_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog(this) != DialogResult.OK) return;
            miExport.Enabled = false;
            tsbExport.Enabled = false;
            toolStripProgressBar1.Visible = true;
            // экспортируем в файл Excel
            try
            {
                var templateName = Path.Combine(Application.StartupPath, "Template.xltx");
                if (!File.Exists(templateName))
                    File.WriteAllBytes(templateName, Properties.Resources.Template);
                toolStripProgressBar1.Value = 0;
                backWorkerExport.RunWorkerAsync(templateName);

            }
            catch (Exception ex)
            {
                miExport.Enabled = true;
                tsbExport.Enabled = true;
                toolStripProgressBar1.Visible = false;
                // при ошибке покажем пользователю сообщение в отдельном окне
                MessageBox.Show(this, ex.Message, @"Ошибка экспорта в Excel", MessageBoxButtons.OK,
                                MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
        }

        private void backWorkerExport_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            var templateName = (string)e.Argument;
            try
            {
                // создаем подключение к Excel
                dynamic xl = Activator.CreateInstance(Type.GetTypeFromProgID("Excel.Application"));
                var outputName = saveFileDialog1.FileName;
                if (File.Exists(outputName)) File.Delete(outputName);
                var wb = xl.Workbooks.Open(templateName, 0, true);
                var sheet = wb.Sheets[1];
                var worker = (System.ComponentModel.BackgroundWorker)sender;
                for (var row = 0; row < _log.Count; row++)
                {
                    if (worker.CancellationPending)
                    {
                        e.Result = new Exception("Прервано пользователем!");
                        break;
                    }
                    var logitem = _log[row];
                    sheet.Cells[row + 2, 1] = logitem.SnapTime; //logitem.SnapTime.ToString("dd.MM.yy HH:mm:ss");
                    sheet.Cells[row + 2, 2] = logitem.DevPath;
                    sheet.Cells[row + 2, 3] = eventmsg[logitem.EventCode];
                    if (logitem.EventCode == 13)
                    {
                        sheet.Cells[row + 2, 4] = logitem.Number.ToString("00000000");
                        sheet.Cells[row + 2, 5] = logitem.Type.ToString("0");
                        sheet.Cells[row + 2, 6] = logitem.Height.ToString("0");
                        sheet.Cells[row + 2, 7] = logitem.Meagure ? "Замер" : "Тип";
                        sheet.Cells[row + 2, 8] = logitem.Setpoint.ToString("0");
                    }
                    worker.ReportProgress((int)(row * 100.0 / _log.Count));
                }
                wb.SaveAs(outputName);
                wb.Close();
                // выгружаем Excel
                xl.Quit();
                GC.Collect();
            }
            catch (Exception ex)
            {
                e.Result = ex;
            }
        }

        private void backWorkerExport_ProgressChanged(object sender, System.ComponentModel.ProgressChangedEventArgs e)
        {
            toolStripProgressBar1.Value = e.ProgressPercentage;
        }

        private void backWorkerExport_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {
            miExport.Enabled = true;
            tsbExport.Enabled = true;
            toolStripProgressBar1.Visible = false;
            if (e.Result is Exception ex)
                MessageBox.Show(this, ex.Message, @"Экспорт в Excel", MessageBoxButtons.OK,
                            MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            else
                MessageBox.Show(this, "Данные успешно записаны", @"Экспорт в Excel", MessageBoxButtons.OK,
                            MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (backWorkerExport.IsBusy) backWorkerExport.CancelAsync();
            while (backWorkerExport.IsBusy) { Application.DoEvents(); }
        }

        void MainFormLoad(object sender, EventArgs e)
		{
            toolStripProgressBar1.Visible = false;
            LoadLog();
			LoadLog(true);
		}
		
		void MiWhereFolderClick(object sender, EventArgs e)
		{
			var frm = new TuningFolderForm(_workPath);
			if (frm.ShowDialog(this) == DialogResult.OK)
			{
				frm.UpdateFolder(ref _workPath);
				mif.WriteString("FolderLocation", "WorkPath", _workPath);
				mif.UpdateFile();
				LoadLog();
  				LoadLog(true);
			}
		}
	}
	
	public class EventItem
	{
		public int EventCode { get; set; }
		public DateTime SnapTime { get; set; }
		public uint Number { get; set; }
		public int Type { get; set; }
		public int Height { get; set; }
		public bool Meagure { get; set; }
		public int Setpoint { get; set; }
		public string DevPath { get; set; }
	}
	
	public class DateFileItem
	{
		public string Text { get; set; }
		public string[] Files { get; set; }
		
		public override string ToString()
		{
			var avals = Text.Split(new [] {'.'});
			return avals.Length == 3 ? string.Concat(avals[2],'.',avals[1],'.',avals[0]) : Text;
		}
	}
}
