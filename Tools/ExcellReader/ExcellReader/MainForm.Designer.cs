namespace ExcellReader
{
    partial class MainForm
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.BtnSelectExcellFile = new System.Windows.Forms.Button();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.BtnCreateDataFile = new System.Windows.Forms.Button();
            this.TBSelectedFilePath = new System.Windows.Forms.TextBox();
            this.TBShowData = new System.Windows.Forms.TextBox();
            this.BtnShowData = new System.Windows.Forms.Button();
            this.TBShowXorFilePath = new System.Windows.Forms.TextBox();
            this.BtnSelectXorScaleFile = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.TBShowXorScaleMessage = new System.Windows.Forms.TextBox();
            this.openXorFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.BtnShowXorScale = new System.Windows.Forms.Button();
            this.BtnCreateCSFiles = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // BtnSelectExcellFile
            // 
            this.BtnSelectExcellFile.Location = new System.Drawing.Point(12, 121);
            this.BtnSelectExcellFile.Name = "BtnSelectExcellFile";
            this.BtnSelectExcellFile.Size = new System.Drawing.Size(120, 25);
            this.BtnSelectExcellFile.TabIndex = 0;
            this.BtnSelectExcellFile.Text = "Select Excell File";
            this.BtnSelectExcellFile.UseVisualStyleBackColor = true;
            this.BtnSelectExcellFile.Click += new System.EventHandler(this.BtnSelectFile_Click);
            // 
            // openFileDialog
            // 
            this.openFileDialog.FileName = "openFileDialog";
            // 
            // BtnCreateDataFile
            // 
            this.BtnCreateDataFile.Location = new System.Drawing.Point(138, 121);
            this.BtnCreateDataFile.Name = "BtnCreateDataFile";
            this.BtnCreateDataFile.Size = new System.Drawing.Size(120, 25);
            this.BtnCreateDataFile.TabIndex = 1;
            this.BtnCreateDataFile.Text = "Create Data File";
            this.BtnCreateDataFile.UseVisualStyleBackColor = true;
            this.BtnCreateDataFile.Click += new System.EventHandler(this.BtnCreateDataFile_Click);
            // 
            // TBSelectedFilePath
            // 
            this.TBSelectedFilePath.Location = new System.Drawing.Point(12, 94);
            this.TBSelectedFilePath.Name = "TBSelectedFilePath";
            this.TBSelectedFilePath.Size = new System.Drawing.Size(600, 21);
            this.TBSelectedFilePath.TabIndex = 2;
            // 
            // TBShowData
            // 
            this.TBShowData.Location = new System.Drawing.Point(12, 152);
            this.TBShowData.Multiline = true;
            this.TBShowData.Name = "TBShowData";
            this.TBShowData.Size = new System.Drawing.Size(600, 246);
            this.TBShowData.TabIndex = 3;
            // 
            // BtnShowData
            // 
            this.BtnShowData.Location = new System.Drawing.Point(12, 404);
            this.BtnShowData.Name = "BtnShowData";
            this.BtnShowData.Size = new System.Drawing.Size(120, 25);
            this.BtnShowData.TabIndex = 4;
            this.BtnShowData.Text = "Show Data";
            this.BtnShowData.UseVisualStyleBackColor = true;
            this.BtnShowData.Click += new System.EventHandler(this.BtnShowData_Click);
            // 
            // TBShowXorFilePath
            // 
            this.TBShowXorFilePath.Location = new System.Drawing.Point(12, 12);
            this.TBShowXorFilePath.Name = "TBShowXorFilePath";
            this.TBShowXorFilePath.Size = new System.Drawing.Size(600, 21);
            this.TBShowXorFilePath.TabIndex = 5;
            // 
            // BtnSelectXorScaleFile
            // 
            this.BtnSelectXorScaleFile.Location = new System.Drawing.Point(12, 39);
            this.BtnSelectXorScaleFile.Name = "BtnSelectXorScaleFile";
            this.BtnSelectXorScaleFile.Size = new System.Drawing.Size(120, 25);
            this.BtnSelectXorScaleFile.TabIndex = 6;
            this.BtnSelectXorScaleFile.Text = "Select XorScale";
            this.BtnSelectXorScaleFile.UseVisualStyleBackColor = true;
            this.BtnSelectXorScaleFile.Click += new System.EventHandler(this.BtnSelectXorScaleFile_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 70);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 12);
            this.label1.TabIndex = 7;
            this.label1.Text = "XorScale:";
            // 
            // TBShowXorScaleMessage
            // 
            this.TBShowXorScaleMessage.Location = new System.Drawing.Point(77, 67);
            this.TBShowXorScaleMessage.Name = "TBShowXorScaleMessage";
            this.TBShowXorScaleMessage.Size = new System.Drawing.Size(535, 21);
            this.TBShowXorScaleMessage.TabIndex = 8;
            // 
            // openXorFileDialog
            // 
            this.openXorFileDialog.FileName = "openXorFileDialog";
            // 
            // BtnShowXorScale
            // 
            this.BtnShowXorScale.Location = new System.Drawing.Point(138, 39);
            this.BtnShowXorScale.Name = "BtnShowXorScale";
            this.BtnShowXorScale.Size = new System.Drawing.Size(120, 25);
            this.BtnShowXorScale.TabIndex = 9;
            this.BtnShowXorScale.Text = "Show XorScale";
            this.BtnShowXorScale.UseVisualStyleBackColor = true;
            this.BtnShowXorScale.Click += new System.EventHandler(this.BtnShowXorScale_Click);
            // 
            // BtnCreateCSFiles
            // 
            this.BtnCreateCSFiles.Location = new System.Drawing.Point(138, 404);
            this.BtnCreateCSFiles.Name = "BtnCreateCSFiles";
            this.BtnCreateCSFiles.Size = new System.Drawing.Size(120, 25);
            this.BtnCreateCSFiles.TabIndex = 10;
            this.BtnCreateCSFiles.Text = "Create CS Files";
            this.BtnCreateCSFiles.UseVisualStyleBackColor = true;
            this.BtnCreateCSFiles.Click += new System.EventHandler(this.BtnCreateCSFile_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(624, 441);
            this.Controls.Add(this.BtnCreateCSFiles);
            this.Controls.Add(this.BtnShowXorScale);
            this.Controls.Add(this.TBShowXorScaleMessage);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.BtnSelectXorScaleFile);
            this.Controls.Add(this.TBShowXorFilePath);
            this.Controls.Add(this.BtnShowData);
            this.Controls.Add(this.TBShowData);
            this.Controls.Add(this.TBSelectedFilePath);
            this.Controls.Add(this.BtnCreateDataFile);
            this.Controls.Add(this.BtnSelectExcellFile);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.Text = "Encrypt & Zip Excell Tool";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button BtnSelectExcellFile;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.Button BtnCreateDataFile;
        private System.Windows.Forms.TextBox TBSelectedFilePath;
        private System.Windows.Forms.TextBox TBShowData;
        private System.Windows.Forms.Button BtnShowData;
        private System.Windows.Forms.TextBox TBShowXorFilePath;
        private System.Windows.Forms.Button BtnSelectXorScaleFile;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox TBShowXorScaleMessage;
        private System.Windows.Forms.OpenFileDialog openXorFileDialog;
        private System.Windows.Forms.Button BtnShowXorScale;
        private System.Windows.Forms.Button BtnCreateCSFiles;
    }
}

