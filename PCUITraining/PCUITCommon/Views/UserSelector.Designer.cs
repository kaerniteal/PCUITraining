namespace PCUITCommon.Views
{
    partial class UserSelector
    {
        /// <summary> 
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージ リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region コンポーネント デザイナーで生成されたコード

        /// <summary> 
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を 
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.tableUserSelect = new System.Windows.Forms.TableLayoutPanel();
            this.flowUserSelect = new System.Windows.Forms.FlowLayoutPanel();
            this.tableUserSelect.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableUserSelect
            // 
            this.tableUserSelect.ColumnCount = 1;
            this.tableUserSelect.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableUserSelect.Controls.Add(this.flowUserSelect, 0, 1);
            this.tableUserSelect.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableUserSelect.Location = new System.Drawing.Point(0, 0);
            this.tableUserSelect.Name = "tableUserSelect";
            this.tableUserSelect.RowCount = 3;
            this.tableUserSelect.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 10F));
            this.tableUserSelect.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableUserSelect.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 10F));
            this.tableUserSelect.Size = new System.Drawing.Size(617, 150);
            this.tableUserSelect.TabIndex = 101;
            // 
            // flowUserSelect
            // 
            this.flowUserSelect.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowUserSelect.Location = new System.Drawing.Point(3, 13);
            this.flowUserSelect.Name = "flowUserSelect";
            this.flowUserSelect.Size = new System.Drawing.Size(611, 124);
            this.flowUserSelect.TabIndex = 0;
            // 
            // UserSelector
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.tableUserSelect);
            this.Name = "UserSelector";
            this.Size = new System.Drawing.Size(617, 150);
            this.tableUserSelect.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableUserSelect;
        private System.Windows.Forms.FlowLayoutPanel flowUserSelect;
    }
}
