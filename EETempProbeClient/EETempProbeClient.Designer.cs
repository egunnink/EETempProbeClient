namespace EETempProbeClient
{
    partial class EETempProbeClient
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.cbComPorts = new System.Windows.Forms.ComboBox();
            this.lblComPorts = new System.Windows.Forms.Label();
            this.pnlGraph = new System.Windows.Forms.Panel();
            this.pvGraph = new OxyPlot.WindowsForms.PlotView();
            this.button1 = new System.Windows.Forms.Button();
            this.pnlGraph.SuspendLayout();
            this.SuspendLayout();
            // 
            // cbComPorts
            // 
            this.cbComPorts.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.cbComPorts.FormattingEnabled = true;
            this.cbComPorts.Location = new System.Drawing.Point(73, 12);
            this.cbComPorts.Name = "cbComPorts";
            this.cbComPorts.Size = new System.Drawing.Size(121, 21);
            this.cbComPorts.TabIndex = 1;
            this.cbComPorts.SelectedIndexChanged += new System.EventHandler(this.cbComPorts_SelectedIndexChanged);
            // 
            // lblComPorts
            // 
            this.lblComPorts.AutoSize = true;
            this.lblComPorts.Location = new System.Drawing.Point(12, 15);
            this.lblComPorts.Name = "lblComPorts";
            this.lblComPorts.Size = new System.Drawing.Size(55, 13);
            this.lblComPorts.TabIndex = 2;
            this.lblComPorts.Text = "Com Ports";
            // 
            // pnlGraph
            // 
            this.pnlGraph.Controls.Add(this.pvGraph);
            this.pnlGraph.Location = new System.Drawing.Point(12, 63);
            this.pnlGraph.Name = "pnlGraph";
            this.pnlGraph.Size = new System.Drawing.Size(1240, 607);
            this.pnlGraph.TabIndex = 3;
            // 
            // pvGraph
            // 
            this.pvGraph.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pvGraph.Location = new System.Drawing.Point(0, 0);
            this.pvGraph.Name = "pvGraph";
            this.pvGraph.PanCursor = System.Windows.Forms.Cursors.Hand;
            this.pvGraph.Size = this.pnlGraph.Size;
            this.pvGraph.TabIndex = 0;
            this.pvGraph.Text = "Temperature";
            this.pvGraph.ZoomHorizontalCursor = System.Windows.Forms.Cursors.SizeWE;
            this.pvGraph.ZoomRectangleCursor = System.Windows.Forms.Cursors.SizeNWSE;
            this.pvGraph.ZoomVerticalCursor = System.Windows.Forms.Cursors.SizeNS;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(350, 9);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 4;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // EETempProbeClient
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1264, 682);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.pnlGraph);
            this.Controls.Add(this.lblComPorts);
            this.Controls.Add(this.cbComPorts);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "EETempProbeClient";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Temp Probe Client ";
            this.Load += new System.EventHandler(this.EETempProbeClient_Load);
            this.pnlGraph.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cbComPorts;
        private System.Windows.Forms.Label lblComPorts;
        private System.Windows.Forms.Panel pnlGraph;
        private OxyPlot.WindowsForms.PlotView pvGraph;
        private System.Windows.Forms.Button button1;
    }
}

