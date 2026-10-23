
namespace CryptoStockTicker
{
    partial class frmCryptoStockTicker
    {
        private System.ComponentModel.IContainer? components = null;

        private System.Windows.Forms.Label lblTitle = null!;
        private System.Windows.Forms.Label lblPriceTitle = null!;
        private System.Windows.Forms.Label lblBTCPrice = null!;
        private System.Windows.Forms.Button btnStart = null!;
        private System.Windows.Forms.Button btnPause = null!;
        private System.Windows.Forms.Label lblHistoryTitle = null!;
        private System.Windows.Forms.DataGridView dgvHistoryLog = null!;
        private System.Windows.Forms.StatusStrip statusStrip = null!;
        private System.Windows.Forms.ToolStripStatusLabel lblStatus = null!;
        private System.Windows.Forms.ToolStripStatusLabel lblLastUpdate = null!;
        private System.Windows.Forms.ToolStripStatusLabel lblSyncCount = null!;

        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null)
            {
                components.Dispose();
            }

            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            lblTitle = new System.Windows.Forms.Label();
            lblPriceTitle = new System.Windows.Forms.Label();
            lblBTCPrice = new System.Windows.Forms.Label();
            btnStart = new System.Windows.Forms.Button();
            btnPause = new System.Windows.Forms.Button();
            lblHistoryTitle = new System.Windows.Forms.Label();
            dgvHistoryLog = new System.Windows.Forms.DataGridView();
            statusStrip = new System.Windows.Forms.StatusStrip();
            lblStatus = new System.Windows.Forms.ToolStripStatusLabel();
            lblLastUpdate = new System.Windows.Forms.ToolStripStatusLabel();
            lblSyncCount = new System.Windows.Forms.ToolStripStatusLabel();

            ((System.ComponentModel.ISupportInitialize)dgvHistoryLog).BeginInit();
            statusStrip.SuspendLayout();
            SuspendLayout();

            // lblTitle
            lblTitle.Dock = System.Windows.Forms.DockStyle.Top;
            lblTitle.Height = 65;
            lblTitle.Text = "GIÁM SÁT TỶ GIÁ BTC/USD";
            lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            lblTitle.Font = new System.Drawing.Font("Segoe UI", 17F, System.Drawing.FontStyle.Bold);

            // lblPriceTitle
            lblPriceTitle.Location = new System.Drawing.Point(30, 85);
            lblPriceTitle.Size = new System.Drawing.Size(200, 30);
            lblPriceTitle.Text = "Giá Bitcoin hiện tại:";
            lblPriceTitle.Font = new System.Drawing.Font("Segoe UI", 11F);

            // lblBTCPrice
            lblBTCPrice.Location = new System.Drawing.Point(30, 120);
            lblBTCPrice.Size = new System.Drawing.Size(420, 60);
            lblBTCPrice.Text = "67,000.00 USD";
            lblBTCPrice.Font = new System.Drawing.Font("Segoe UI", 25F, System.Drawing.FontStyle.Bold);
            lblBTCPrice.ForeColor = System.Drawing.Color.Black;
            lblBTCPrice.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;

            // btnStart
            btnStart.Location = new System.Drawing.Point(500, 105);
            btnStart.Size = new System.Drawing.Size(180, 45);
            btnStart.Text = "Bắt đầu Giám sát";
            btnStart.Font = new System.Drawing.Font("Segoe UI", 10F);
            btnStart.UseVisualStyleBackColor = true;
            btnStart.Click += btnStart_Click;

            // btnPause
            btnPause.Location = new System.Drawing.Point(700, 105);
            btnPause.Size = new System.Drawing.Size(140, 45);
            btnPause.Text = "Tạm dừng";
            btnPause.Font = new System.Drawing.Font("Segoe UI", 10F);
            btnPause.UseVisualStyleBackColor = true;
            btnPause.Click += btnPause_Click;

            // lblHistoryTitle
            lblHistoryTitle.Location = new System.Drawing.Point(30, 205);
            lblHistoryTitle.Size = new System.Drawing.Size(400, 30);
            lblHistoryTitle.Text = "NHẬT KÝ BIẾN ĐỘNG TỶ GIÁ";
            lblHistoryTitle.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);

            // dgvHistoryLog
            dgvHistoryLog.Location = new System.Drawing.Point(30, 245);
            dgvHistoryLog.Size = new System.Drawing.Size(810, 300);
            dgvHistoryLog.Anchor =
                System.Windows.Forms.AnchorStyles.Top |
                System.Windows.Forms.AnchorStyles.Bottom |
                System.Windows.Forms.AnchorStyles.Left |
                System.Windows.Forms.AnchorStyles.Right;

            dgvHistoryLog.BackgroundColor = System.Drawing.Color.White;
            dgvHistoryLog.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            dgvHistoryLog.RowHeadersVisible = false;
            dgvHistoryLog.AutoSizeColumnsMode =
                System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dgvHistoryLog.AllowUserToAddRows = false;
            dgvHistoryLog.ReadOnly = true;
            dgvHistoryLog.SelectionMode =
                System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;

            dgvHistoryLog.Columns.Add("colSTT", "Lần");
            dgvHistoryLog.Columns.Add("colTime", "Thời gian");
            dgvHistoryLog.Columns.Add("colPrice", "Giá BTC (USD)");
            dgvHistoryLog.Columns.Add("colChange", "Biến động (USD)");
            dgvHistoryLog.Columns.Add("colTrend", "Xu hướng");

            dgvHistoryLog.Columns["colSTT"].FillWeight = 45;
            dgvHistoryLog.Columns["colTime"].FillWeight = 90;
            dgvHistoryLog.Columns["colPrice"].FillWeight = 125;
            dgvHistoryLog.Columns["colChange"].FillWeight = 125;
            dgvHistoryLog.Columns["colTrend"].FillWeight = 75;

            // statusStrip
            statusStrip.Dock = System.Windows.Forms.DockStyle.Bottom;
            statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[]
            {
                lblStatus,
                new System.Windows.Forms.ToolStripStatusLabel()
                {
                    Spring = true
                },
                lblLastUpdate,
                new System.Windows.Forms.ToolStripStatusLabel()
                {
                    Text = " | "
                },
                lblSyncCount
            });

            lblStatus.Text = "Trạng thái: Chưa chạy";
            lblLastUpdate.Text = "Lần cập nhật cuối: --:--:--";
            lblSyncCount.Text = "Số lượt đồng bộ: 0";

            // Form
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(880, 600);
            MinimumSize = new System.Drawing.Size(800, 550);
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "CryptoStockTicker - Giám sát tỷ giá";
            Font = new System.Drawing.Font("Segoe UI", 9F);

            Controls.Add(lblTitle);
            Controls.Add(lblPriceTitle);
            Controls.Add(lblBTCPrice);
            Controls.Add(btnStart);
            Controls.Add(btnPause);
            Controls.Add(lblHistoryTitle);
            Controls.Add(dgvHistoryLog);
            Controls.Add(statusStrip);

            ((System.ComponentModel.ISupportInitialize)dgvHistoryLog).EndInit();
            statusStrip.ResumeLayout(false);
            statusStrip.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }
    }
}
