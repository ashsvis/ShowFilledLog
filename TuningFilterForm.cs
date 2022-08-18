using System;
using System.Windows.Forms;
using System.Collections.Generic;

namespace ShowFilledLog
{
	/// <summary>
	/// Description of TuningFilterForm.
	/// </summary>
	public partial class TuningFilterForm : Form
	{
		private string[] _eventmsg;
		private bool[] _eventmask;
		private Dictionary<string, bool> _devmask;
		private int _tabIndex;
		
		public TuningFilterForm(int tabIndex, string[] eventmsg, bool[] eventmask, Dictionary<string, bool> devmask, 
		                        bool firstDateChecked, DateTime firstDate, bool lastDateChecked, DateTime lastDate)
		{
			InitializeComponent();
			_eventmsg = eventmsg;
			_eventmask = eventmask;
			FillEventsList(_eventmsg, _eventmask);
			_devmask = new Dictionary<string, bool>(devmask);
			FillDevicesList(_devmask);
			cbBeginDateFilter.Checked = firstDateChecked;
			dtpBeginDate.Value = dtpBeginTime.Value = 
				firstDate < dtpBeginDate.MinDate ? dtpBeginDate.MinDate : firstDate;
			cbEndDateFilter.Checked = lastDateChecked;
			dtpEndDate.Value = dtpEndTime.Value = 
				lastDate > dtpEndDate.MaxDate ? dtpEndDate.MaxDate : lastDate;
			_tabIndex = tabIndex;
		}
		
		public void FillDevicesList(Dictionary<string, bool> devmask, bool? flags = null)
		{
			try
			{
				lvDevices.BeginUpdate();
				lvDevices.Items.Clear();
				foreach (var key in devmask.Keys)
				{
					var lvi = new ListViewItem(key);
					if (flags != null)
					{
						lvi.Checked = (bool)flags;
					}
					else
					{
						lvi.Checked = devmask[key];
					}
					lvDevices.Items.Add(lvi);
				}
			}
			finally
			{
				lvDevices.EndUpdate();
			}
		}
	
		public void FillEventsList(string[] eventmsg, bool[] eventmask, bool? flags = null)
		{
			try
			{
				lvEvents.BeginUpdate();
				lvEvents.Items.Clear();
				var i = 0;
				foreach (var item in eventmsg)
				{
					var lvi = new ListViewItem(item);
					if (flags != null)
					{
						lvi.Checked = (bool)flags;
					}
					else
					{
						lvi.Checked = eventmask[i];
					}
					lvEvents.Items.Add(lvi);
					i++;
				}
			}
			finally
			{
				lvEvents.EndUpdate();
			}
		}
		
		public void UpdateTabIndex(ref int tabIndex)
		{
			tabIndex = tabControl1.SelectedTab.TabIndex;
		}
		
		public void UpdateEventsMask(ref bool[] eventmask)
		{
			var i = 0;
			foreach (ListViewItem lvi in lvEvents.Items)
			{
				eventmask[i] = lvi.Checked;
				i++;
			}
		}
		
		public void UpdateDevicesMask(ref Dictionary<string, bool> devmask)
		{
			var i = 0;
			foreach (ListViewItem lvi in lvDevices.Items)
			{
				var key = lvi.Text;
				if (devmask.ContainsKey(key))
					devmask[key] = lvi.Checked;
				i++;
			}
		}
		
		public void UpdateDateRange(ref bool firstDateChecked, ref DateTime firstDate, 
		                            ref bool lastDateChecked, ref DateTime lastDate)
		{
			firstDate = dtpBeginDate.Value.Date + dtpBeginTime.Value.TimeOfDay;
			firstDateChecked = cbBeginDateFilter.Checked;
			lastDate = dtpEndDate.Value.Date + dtpEndTime.Value.TimeOfDay;
			lastDateChecked = cbEndDateFilter.Checked;
		}
		
		void BtnSetAllEventsClick(object sender, EventArgs e)
		{
			FillEventsList(_eventmsg, _eventmask, true);
		}
		
		void BtnClearAllEventsClick(object sender, EventArgs e)
		{
			FillEventsList(_eventmsg, _eventmask, false);
		}
		
		void BtnSetAllDevicesClick(object sender, EventArgs e)
		{
			FillDevicesList(_devmask, true);
		}
		
		void BtnClearAllDevicesClick(object sender, EventArgs e)
		{
			FillDevicesList(_devmask, false);
		}
		
		void TuningFilterFormLoad(object sender, EventArgs e)
		{
			switch (_tabIndex)
			{
				case 0:
					tabControl1.SelectedTab = tbEvents;
					break;
				case 1:
					tabControl1.SelectedTab = tbDevices;
					break;
				case 2:
					tabControl1.SelectedTab = tbDateTime;
					break;
			}
		}
	}
}
