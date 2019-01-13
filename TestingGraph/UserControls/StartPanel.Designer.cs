namespace TestingGraph.UserControls
{
    partial class StartPanel
    {
        /// <summary> 
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором компонентов

        /// <summary> 
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.LinksButton = new System.Windows.Forms.Button();
            this.IntButton = new System.Windows.Forms.Button();
            this.SmezButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // LinksButton
            // 
            this.LinksButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.LinksButton.Location = new System.Drawing.Point(239, 263);
            this.LinksButton.Margin = new System.Windows.Forms.Padding(4);
            this.LinksButton.Name = "LinksButton";
            this.LinksButton.Size = new System.Drawing.Size(250, 45);
            this.LinksButton.TabIndex = 29;
            this.LinksButton.Text = "Список ребер";
            this.LinksButton.UseVisualStyleBackColor = true;
            this.LinksButton.Click += new System.EventHandler(this.LinksButton_Click);
            // 
            // IntButton
            // 
            this.IntButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.IntButton.Location = new System.Drawing.Point(239, 188);
            this.IntButton.Margin = new System.Windows.Forms.Padding(4);
            this.IntButton.Name = "IntButton";
            this.IntButton.Size = new System.Drawing.Size(250, 48);
            this.IntButton.TabIndex = 28;
            this.IntButton.Text = "Матрица инцидентности";
            this.IntButton.UseVisualStyleBackColor = true;
            this.IntButton.Click += new System.EventHandler(this.IntButton_Click);
            // 
            // SmezButton
            // 
            this.SmezButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.SmezButton.Location = new System.Drawing.Point(239, 119);
            this.SmezButton.Margin = new System.Windows.Forms.Padding(4);
            this.SmezButton.Name = "SmezButton";
            this.SmezButton.Size = new System.Drawing.Size(250, 47);
            this.SmezButton.TabIndex = 27;
            this.SmezButton.Text = "Матрица смежности";
            this.SmezButton.UseVisualStyleBackColor = true;
            this.SmezButton.Click += new System.EventHandler(this.SmezButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(137, 66);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(418, 29);
            this.label1.TabIndex = 26;
            this.label1.Text = "Выберите тип исходных данных:";
            // 
            // StartPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.LinksButton);
            this.Controls.Add(this.IntButton);
            this.Controls.Add(this.SmezButton);
            this.Controls.Add(this.label1);
            this.Name = "StartPanel";
            this.Size = new System.Drawing.Size(740, 451);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button LinksButton;
        private System.Windows.Forms.Button IntButton;
        private System.Windows.Forms.Button SmezButton;
        private System.Windows.Forms.Label label1;
    }
}
