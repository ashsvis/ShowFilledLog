/*
 * Created by SharpDevelop.
 * User: Сектор2
 * Date: 07.08.2018
 * Time: 9:19
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace ShowFilledLog
{
	partial class TuningFilterForm
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		
		/// <summary>
		/// Disposes resources used by the form.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing) {
				if (components != null) {
					components.Dispose();
				}
			}
			base.Dispose(disposing);
		}
		
		/// <summary>
		/// This method is required for Windows Forms designer support.
		/// Do not change the method contents inside the source code editor. The Forms designer might
		/// not be able to load this method if it was changed manually.
		/// </summary>
		private void InitializeComponent()
		{
			this.tabControl1 = new System.Windows.Forms.TabControl();
			this.tbEvents = new System.Windows.Forms.TabPage();
			this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
			this.lvEvents = new System.Windows.Forms.ListView();
			this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
			this.panel1 = new System.Windows.Forms.Panel();
			this.btnClearAllEvents = new System.Windows.Forms.Button();
			this.btnSetAllEvents = new System.Windows.Forms.Button();
			this.tbDevices = new System.Windows.Forms.TabPage();
			this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
			this.lvDevices = new System.Windows.Forms.ListView();
			this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
			this.panel2 = new System.Windows.Forms.Panel();
			this.btnClearAllDevices = new System.Windows.Forms.Button();
			this.btnSetAllDevices = new System.Windows.Forms.Button();
			this.tbDateTime = new System.Windows.Forms.TabPage();
			this.dtpEndTime = new System.Windows.Forms.DateTimePicker();
			this.dtpBeginTime = new System.Windows.Forms.DateTimePicker();
			this.dtpEndDate = new System.Windows.Forms.DateTimePicker();
			this.cbEndDateFilter = new System.Windows.Forms.CheckBox();
			this.dtpBeginDate = new System.Windows.Forms.DateTimePicker();
			this.cbBeginDateFilter = new System.Windows.Forms.CheckBox();
			this.btnOk = new System.Windows.Forms.Button();
			this.btnCancel = new System.Windows.Forms.Button();
			this.tabControl1.SuspendLayout();
			this.tbEvents.SuspendLayout();
			this.tableLayoutPanel1.SuspendLayout();
			this.panel1.SuspendLayout();
			this.tbDevices.SuspendLayout();
			this.tableLayoutPanel2.SuspendLayout();
			this.panel2.SuspendLayout();
			this.tbDateTime.SuspendLayout();
			this.SuspendLayout();
			// 
			// tabControl1
			// 
			this.tabControl1.Controls.Add(this.tbEvents);
			this.tabControl1.Controls.Add(this.tbDevices);
			this.tabControl1.Controls.Add(this.tbDateTime);
			this.tabControl1.Location = new System.Drawing.Point(12, 12);
			this.tabControl1.Name = "tabControl1";
			this.tabControl1.SelectedIndex = 0;
			this.tabControl1.Size = new System.Drawing.Size(582, 319);
			this.tabControl1.TabIndex = 0;
			// 
			// tbEvents
			// 
			this.tbEvents.Controls.Add(this.tableLayoutPanel1);
			this.tbEvents.Location = new System.Drawing.Point(4, 24);
			this.tbEvents.Name = "tbEvents";
			this.tbEvents.Padding = new System.Windows.Forms.Padding(3);
			this.tbEvents.Size = new System.Drawing.Size(574, 291);
			this.tbEvents.TabIndex = 0;
			this.tbEvents.Text = "События";
			this.tbEvents.UseVisualStyleBackColor = true;
			// 
			// tableLayoutPanel1
			// 
			this.tableLayoutPanel1.ColumnCount = 1;
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanel1.Controls.Add(this.lvEvents, 0, 0);
			this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 1);
			this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 3);
			this.tableLayoutPanel1.Name = "tableLayoutPanel1";
			this.tableLayoutPanel1.RowCount = 2;
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
			this.tableLayoutPanel1.Size = new System.Drawing.Size(568, 285);
			this.tableLayoutPanel1.TabIndex = 1;
			// 
			// lvEvents
			// 
			this.lvEvents.CheckBoxes = true;
			this.lvEvents.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
									this.columnHeader1});
			this.lvEvents.Dock = System.Windows.Forms.DockStyle.Fill;
			this.lvEvents.GridLines = true;
			this.lvEvents.Location = new System.Drawing.Point(3, 3);
			this.lvEvents.Name = "lvEvents";
			this.lvEvents.Size = new System.Drawing.Size(562, 239);
			this.lvEvents.TabIndex = 0;
			this.lvEvents.UseCompatibleStateImageBehavior = false;
			this.lvEvents.View = System.Windows.Forms.View.Details;
			// 
			// columnHeader1
			// 
			this.columnHeader1.Text = "Список событий";
			this.columnHeader1.Width = 536;
			// 
			// panel1
			// 
			this.panel1.Controls.Add(this.btnClearAllEvents);
			this.panel1.Controls.Add(this.btnSetAllEvents);
			this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel1.Location = new System.Drawing.Point(3, 248);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(562, 34);
			this.panel1.TabIndex = 1;
			// 
			// btnClearAllEvents
			// 
			this.btnClearAllEvents.Location = new System.Drawing.Point(114, 3);
			this.btnClearAllEvents.Name = "btnClearAllEvents";
			this.btnClearAllEvents.Size = new System.Drawing.Size(107, 26);
			this.btnClearAllEvents.TabIndex = 2;
			this.btnClearAllEvents.Text = "Очистить все";
			this.btnClearAllEvents.UseVisualStyleBackColor = true;
			this.btnClearAllEvents.Click += new System.EventHandler(this.BtnClearAllEventsClick);
			// 
			// btnSetAllEvents
			// 
			this.btnSetAllEvents.Location = new System.Drawing.Point(3, 3);
			this.btnSetAllEvents.Name = "btnSetAllEvents";
			this.btnSetAllEvents.Size = new System.Drawing.Size(107, 26);
			this.btnSetAllEvents.TabIndex = 1;
			this.btnSetAllEvents.Text = "Установить все";
			this.btnSetAllEvents.UseVisualStyleBackColor = true;
			this.btnSetAllEvents.Click += new System.EventHandler(this.BtnSetAllEventsClick);
			// 
			// tbDevices
			// 
			this.tbDevices.Controls.Add(this.tableLayoutPanel2);
			this.tbDevices.Location = new System.Drawing.Point(4, 24);
			this.tbDevices.Name = "tbDevices";
			this.tbDevices.Padding = new System.Windows.Forms.Padding(3);
			this.tbDevices.Size = new System.Drawing.Size(574, 291);
			this.tbDevices.TabIndex = 1;
			this.tbDevices.Text = "Устройства";
			this.tbDevices.UseVisualStyleBackColor = true;
			// 
			// tableLayoutPanel2
			// 
			this.tableLayoutPanel2.ColumnCount = 1;
			this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanel2.Controls.Add(this.lvDevices, 0, 0);
			this.tableLayoutPanel2.Controls.Add(this.panel2, 0, 1);
			this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 3);
			this.tableLayoutPanel2.Name = "tableLayoutPanel2";
			this.tableLayoutPanel2.RowCount = 2;
			this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
			this.tableLayoutPanel2.Size = new System.Drawing.Size(568, 285);
			this.tableLayoutPanel2.TabIndex = 2;
			// 
			// lvDevices
			// 
			this.lvDevices.CheckBoxes = true;
			this.lvDevices.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
									this.columnHeader2});
			this.lvDevices.Dock = System.Windows.Forms.DockStyle.Fill;
			this.lvDevices.GridLines = true;
			this.lvDevices.Location = new System.Drawing.Point(3, 3);
			this.lvDevices.Name = "lvDevices";
			this.lvDevices.Size = new System.Drawing.Size(562, 239);
			this.lvDevices.TabIndex = 0;
			this.lvDevices.UseCompatibleStateImageBehavior = false;
			this.lvDevices.View = System.Windows.Forms.View.Details;
			// 
			// columnHeader2
			// 
			this.columnHeader2.Text = "Список устройств";
			this.columnHeader2.Width = 536;
			// 
			// panel2
			// 
			this.panel2.Controls.Add(this.btnClearAllDevices);
			this.panel2.Controls.Add(this.btnSetAllDevices);
			this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel2.Location = new System.Drawing.Point(3, 248);
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size(562, 34);
			this.panel2.TabIndex = 1;
			// 
			// btnClearAllDevices
			// 
			this.btnClearAllDevices.Location = new System.Drawing.Point(114, 3);
			this.btnClearAllDevices.Name = "btnClearAllDevices";
			this.btnClearAllDevices.Size = new System.Drawing.Size(107, 26);
			this.btnClearAllDevices.TabIndex = 2;
			this.btnClearAllDevices.Text = "Очистить все";
			this.btnClearAllDevices.UseVisualStyleBackColor = true;
			this.btnClearAllDevices.Click += new System.EventHandler(this.BtnClearAllDevicesClick);
			// 
			// btnSetAllDevices
			// 
			this.btnSetAllDevices.Location = new System.Drawing.Point(3, 3);
			this.btnSetAllDevices.Name = "btnSetAllDevices";
			this.btnSetAllDevices.Size = new System.Drawing.Size(107, 26);
			this.btnSetAllDevices.TabIndex = 1;
			this.btnSetAllDevices.Text = "Установить все";
			this.btnSetAllDevices.UseVisualStyleBackColor = true;
			this.btnSetAllDevices.Click += new System.EventHandler(this.BtnSetAllDevicesClick);
			// 
			// tbDateTime
			// 
			this.tbDateTime.Controls.Add(this.dtpEndTime);
			this.tbDateTime.Controls.Add(this.dtpBeginTime);
			this.tbDateTime.Controls.Add(this.dtpEndDate);
			this.tbDateTime.Controls.Add(this.cbEndDateFilter);
			this.tbDateTime.Controls.Add(this.dtpBeginDate);
			this.tbDateTime.Controls.Add(this.cbBeginDateFilter);
			this.tbDateTime.Location = new System.Drawing.Point(4, 24);
			this.tbDateTime.Name = "tbDateTime";
			this.tbDateTime.Padding = new System.Windows.Forms.Padding(3);
			this.tbDateTime.Size = new System.Drawing.Size(574, 291);
			this.tbDateTime.TabIndex = 2;
			this.tbDateTime.Text = "Дата и время";
			this.tbDateTime.UseVisualStyleBackColor = true;
			// 
			// dtpEndTime
			// 
			this.dtpEndTime.Format = System.Windows.Forms.DateTimePickerFormat.Time;
			this.dtpEndTime.Location = new System.Drawing.Point(391, 75);
			this.dtpEndTime.Name = "dtpEndTime";
			this.dtpEndTime.ShowUpDown = true;
			this.dtpEndTime.Size = new System.Drawing.Size(89, 21);
			this.dtpEndTime.TabIndex = 5;
			// 
			// dtpBeginTime
			// 
			this.dtpBeginTime.Format = System.Windows.Forms.DateTimePickerFormat.Time;
			this.dtpBeginTime.Location = new System.Drawing.Point(391, 38);
			this.dtpBeginTime.Name = "dtpBeginTime";
			this.dtpBeginTime.ShowUpDown = true;
			this.dtpBeginTime.Size = new System.Drawing.Size(89, 21);
			this.dtpBeginTime.TabIndex = 2;
			// 
			// dtpEndDate
			// 
			this.dtpEndDate.Location = new System.Drawing.Point(233, 76);
			this.dtpEndDate.Name = "dtpEndDate";
			this.dtpEndDate.Size = new System.Drawing.Size(152, 21);
			this.dtpEndDate.TabIndex = 4;
			// 
			// cbEndDateFilter
			// 
			this.cbEndDateFilter.Location = new System.Drawing.Point(67, 76);
			this.cbEndDateFilter.Name = "cbEndDateFilter";
			this.cbEndDateFilter.Size = new System.Drawing.Size(160, 24);
			this.cbEndDateFilter.TabIndex = 3;
			this.cbEndDateFilter.Text = "конечное время лога";
			this.cbEndDateFilter.UseVisualStyleBackColor = true;
			// 
			// dtpBeginDate
			// 
			this.dtpBeginDate.Location = new System.Drawing.Point(233, 39);
			this.dtpBeginDate.Name = "dtpBeginDate";
			this.dtpBeginDate.Size = new System.Drawing.Size(152, 21);
			this.dtpBeginDate.TabIndex = 1;
			// 
			// cbBeginDateFilter
			// 
			this.cbBeginDateFilter.Location = new System.Drawing.Point(67, 39);
			this.cbBeginDateFilter.Name = "cbBeginDateFilter";
			this.cbBeginDateFilter.Size = new System.Drawing.Size(160, 24);
			this.cbBeginDateFilter.TabIndex = 0;
			this.cbBeginDateFilter.Text = "начальное время лога";
			this.cbBeginDateFilter.UseVisualStyleBackColor = true;
			// 
			// btnOk
			// 
			this.btnOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.btnOk.Location = new System.Drawing.Point(434, 338);
			this.btnOk.Name = "btnOk";
			this.btnOk.Size = new System.Drawing.Size(75, 25);
			this.btnOk.TabIndex = 1;
			this.btnOk.Text = "Ok";
			this.btnOk.UseVisualStyleBackColor = true;
			// 
			// btnCancel
			// 
			this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnCancel.Location = new System.Drawing.Point(515, 338);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new System.Drawing.Size(75, 25);
			this.btnCancel.TabIndex = 2;
			this.btnCancel.Text = "Отмена";
			this.btnCancel.UseVisualStyleBackColor = true;
			// 
			// TuningFilterForm
			// 
			this.AcceptButton = this.btnOk;
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.btnCancel;
			this.ClientSize = new System.Drawing.Size(606, 372);
			this.Controls.Add(this.btnCancel);
			this.Controls.Add(this.btnOk);
			this.Controls.Add(this.tabControl1);
			this.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "TuningFilterForm";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Фильтр журнала";
			this.Load += new System.EventHandler(this.TuningFilterFormLoad);
			this.tabControl1.ResumeLayout(false);
			this.tbEvents.ResumeLayout(false);
			this.tableLayoutPanel1.ResumeLayout(false);
			this.panel1.ResumeLayout(false);
			this.tbDevices.ResumeLayout(false);
			this.tableLayoutPanel2.ResumeLayout(false);
			this.panel2.ResumeLayout(false);
			this.tbDateTime.ResumeLayout(false);
			this.ResumeLayout(false);
		}
		private System.Windows.Forms.CheckBox cbBeginDateFilter;
		private System.Windows.Forms.DateTimePicker dtpBeginDate;
		private System.Windows.Forms.CheckBox cbEndDateFilter;
		private System.Windows.Forms.DateTimePicker dtpEndDate;
		private System.Windows.Forms.DateTimePicker dtpBeginTime;
		private System.Windows.Forms.DateTimePicker dtpEndTime;
		private System.Windows.Forms.Button btnSetAllDevices;
		private System.Windows.Forms.Button btnClearAllDevices;
		private System.Windows.Forms.Panel panel2;
		private System.Windows.Forms.ColumnHeader columnHeader2;
		private System.Windows.Forms.ListView lvDevices;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
		private System.Windows.Forms.Button btnSetAllEvents;
		private System.Windows.Forms.Button btnClearAllEvents;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
		private System.Windows.Forms.ColumnHeader columnHeader1;
		private System.Windows.Forms.ListView lvEvents;
		private System.Windows.Forms.TabPage tbDateTime;
		private System.Windows.Forms.Button btnCancel;
		private System.Windows.Forms.Button btnOk;
		private System.Windows.Forms.TabPage tbDevices;
		private System.Windows.Forms.TabPage tbEvents;
		private System.Windows.Forms.TabControl tabControl1;
	}
}
