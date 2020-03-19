namespace BIL3003_Odev_2
{
    partial class Form1
    {
        /// <summary>
        ///Gerekli tasarımcı değişkeni.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///Kullanılan tüm kaynakları temizleyin.
        /// </summary>
        ///<param name="disposing">yönetilen kaynaklar dispose edilmeliyse doğru; aksi halde yanlış.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer üretilen kod

        /// <summary>
        /// Tasarımcı desteği için gerekli metot - bu metodun 
        ///içeriğini kod düzenleyici ile değiştirmeyin.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            this.start = new System.Windows.Forms.Button();
            this.epsilon = new System.Windows.Forms.TextBox();
            this.minNumPoint = new System.Windows.Forms.TextBox();
            this.epsilonLab = new System.Windows.Forms.Label();
            this.minNumPointLab = new System.Windows.Forms.Label();
            this.chartButton = new System.Windows.Forms.Button();
            this.dataChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.xAxisCombo = new System.Windows.Forms.ComboBox();
            this.yAxisCombo = new System.Windows.Forms.ComboBox();
            this.xAxisLabel = new System.Windows.Forms.Label();
            this.yAxisLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataChart)).BeginInit();
            this.SuspendLayout();
            // 
            // start
            // 
            this.start.Location = new System.Drawing.Point(15, 66);
            this.start.Name = "start";
            this.start.Size = new System.Drawing.Size(75, 23);
            this.start.TabIndex = 0;
            this.start.Text = "Start";
            this.start.UseVisualStyleBackColor = true;
            this.start.Click += new System.EventHandler(this.start_Click);
            // 
            // epsilon
            // 
            this.epsilon.Location = new System.Drawing.Point(123, 12);
            this.epsilon.Name = "epsilon";
            this.epsilon.Size = new System.Drawing.Size(100, 20);
            this.epsilon.TabIndex = 1;
            // 
            // minNumPoint
            // 
            this.minNumPoint.Location = new System.Drawing.Point(123, 38);
            this.minNumPoint.Name = "minNumPoint";
            this.minNumPoint.Size = new System.Drawing.Size(100, 20);
            this.minNumPoint.TabIndex = 2;
            // 
            // epsilonLab
            // 
            this.epsilonLab.AutoSize = true;
            this.epsilonLab.Location = new System.Drawing.Point(12, 15);
            this.epsilonLab.Name = "epsilonLab";
            this.epsilonLab.Size = new System.Drawing.Size(41, 13);
            this.epsilonLab.TabIndex = 3;
            this.epsilonLab.Text = "Epsilon";
            // 
            // minNumPointLab
            // 
            this.minNumPointLab.AutoSize = true;
            this.minNumPointLab.Location = new System.Drawing.Point(12, 41);
            this.minNumPointLab.Name = "minNumPointLab";
            this.minNumPointLab.Size = new System.Drawing.Size(105, 13);
            this.minNumPointLab.TabIndex = 4;
            this.minNumPointLab.Text = "Min number of points";
            // 
            // chartButton
            // 
            this.chartButton.Location = new System.Drawing.Point(12, 238);
            this.chartButton.Name = "chartButton";
            this.chartButton.Size = new System.Drawing.Size(75, 23);
            this.chartButton.TabIndex = 5;
            this.chartButton.Text = "Draw Chart";
            this.chartButton.UseVisualStyleBackColor = true;
            this.chartButton.Visible = false;
            this.chartButton.Click += new System.EventHandler(this.chartButton_Click);
            // 
            // dataChart
            // 
            chartArea1.Name = "ChartArea1";
            this.dataChart.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.dataChart.Legends.Add(legend1);
            this.dataChart.Location = new System.Drawing.Point(245, 12);
            this.dataChart.Name = "dataChart";
            this.dataChart.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.Bright;
            this.dataChart.Size = new System.Drawing.Size(488, 472);
            this.dataChart.TabIndex = 6;
            this.dataChart.Text = "chart1";
            this.dataChart.Visible = false;
            this.dataChart.MouseClick += new System.Windows.Forms.MouseEventHandler(this.dataChart_MouseClick);
            // 
            // xAxisCombo
            // 
            this.xAxisCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.xAxisCombo.FormattingEnabled = true;
            this.xAxisCombo.Location = new System.Drawing.Point(102, 169);
            this.xAxisCombo.Name = "xAxisCombo";
            this.xAxisCombo.Size = new System.Drawing.Size(121, 21);
            this.xAxisCombo.TabIndex = 7;
            this.xAxisCombo.Visible = false;
            // 
            // yAxisCombo
            // 
            this.yAxisCombo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.yAxisCombo.FormattingEnabled = true;
            this.yAxisCombo.Location = new System.Drawing.Point(102, 210);
            this.yAxisCombo.Name = "yAxisCombo";
            this.yAxisCombo.Size = new System.Drawing.Size(121, 21);
            this.yAxisCombo.TabIndex = 8;
            this.yAxisCombo.Visible = false;
            // 
            // xAxisLabel
            // 
            this.xAxisLabel.AutoSize = true;
            this.xAxisLabel.Location = new System.Drawing.Point(12, 172);
            this.xAxisLabel.Name = "xAxisLabel";
            this.xAxisLabel.Size = new System.Drawing.Size(39, 13);
            this.xAxisLabel.TabIndex = 9;
            this.xAxisLabel.Text = "X Axis:";
            this.xAxisLabel.Visible = false;
            // 
            // yAxisLabel
            // 
            this.yAxisLabel.AutoSize = true;
            this.yAxisLabel.Location = new System.Drawing.Point(12, 213);
            this.yAxisLabel.Name = "yAxisLabel";
            this.yAxisLabel.Size = new System.Drawing.Size(39, 13);
            this.yAxisLabel.TabIndex = 10;
            this.yAxisLabel.Text = "Y Axis:";
            this.yAxisLabel.Visible = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(745, 496);
            this.Controls.Add(this.yAxisLabel);
            this.Controls.Add(this.xAxisLabel);
            this.Controls.Add(this.yAxisCombo);
            this.Controls.Add(this.xAxisCombo);
            this.Controls.Add(this.dataChart);
            this.Controls.Add(this.chartButton);
            this.Controls.Add(this.minNumPointLab);
            this.Controls.Add(this.epsilonLab);
            this.Controls.Add(this.minNumPoint);
            this.Controls.Add(this.epsilon);
            this.Controls.Add(this.start);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataChart)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button start;
        private System.Windows.Forms.TextBox epsilon;
        private System.Windows.Forms.TextBox minNumPoint;
        private System.Windows.Forms.Label epsilonLab;
        private System.Windows.Forms.Label minNumPointLab;
        private System.Windows.Forms.Button chartButton;
        private System.Windows.Forms.DataVisualization.Charting.Chart dataChart;
        private System.Windows.Forms.ComboBox xAxisCombo;
        private System.Windows.Forms.ComboBox yAxisCombo;
        private System.Windows.Forms.Label xAxisLabel;
        private System.Windows.Forms.Label yAxisLabel;
    }
}

