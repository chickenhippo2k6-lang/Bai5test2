
using System;
using System.Drawing;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CryptoStockTicker
{
    public partial class frmCryptoStockTicker : Form
    {
        private decimal giaBTC = 67000m;
        private int soLanDongBo = 0;

        private CancellationTokenSource? huyTheoDoi;
        private Task? tienTrinhNen;

        private readonly Random random = new Random();
        private volatile bool dangDongForm = false;

        public frmCryptoStockTicker()
        {
            InitializeComponent();

            lblBTCPrice.Text = giaBTC.ToString("N2") + " USD";
            lblBTCPrice.ForeColor = Color.Black;

            lblLastUpdate.Text = "Lần cập nhật cuối: --:--:--";
            lblSyncCount.Text = "Số lượt đồng bộ: 0";
            lblStatus.Text = "Trạng thái: Chưa chạy";

            btnPause.Enabled = false;

            dgvHistoryLog.AutoGenerateColumns = false;
            dgvHistoryLog.AllowUserToAddRows = false;
            dgvHistoryLog.ReadOnly = true;
            dgvHistoryLog.SelectionMode =
                DataGridViewSelectionMode.FullRowSelect;
        }

        private async void btnStart_Click(object? sender, EventArgs e)
        {
            if (dangDongForm)
                return;

            if (tienTrinhNen != null && !tienTrinhNen.IsCompleted)
                return;

            huyTheoDoi?.Dispose();
            huyTheoDoi = new CancellationTokenSource();

            CancellationToken token = huyTheoDoi.Token;

            btnStart.Enabled = false;
            btnPause.Enabled = true;
            lblStatus.Text = "Trạng thái: Đang giám sát";

            tienTrinhNen = Task.Run(
                () => GiamSatGiaBTC(token), token);

            try
            {
                await tienTrinhNen;
            }
            catch (OperationCanceledException)
            {
                // Tác vụ kết thúc khi nhận yêu cầu hủy.
            }
            finally
            {
                if (!dangDongForm && !IsDisposed)
                {
                    btnStart.Enabled = true;
                    btnPause.Enabled = false;
                    lblStatus.Text = "Trạng thái: Đã tạm dừng";
                }

                huyTheoDoi?.Dispose();
                huyTheoDoi = null;
                tienTrinhNen = null;
            }
        }

        private void btnPause_Click(object? sender, EventArgs e)
        {
            huyTheoDoi?.Cancel();

            btnPause.Enabled = false;
            lblStatus.Text = "Trạng thái: Đang dừng...";
        }

        private async Task GiamSatGiaBTC(CancellationToken token)
        {
            while (true)
            {
                token.ThrowIfCancellationRequested();

                await Task.Delay(2000, token).ConfigureAwait(false);

                token.ThrowIfCancellationRequested();

                if (dangDongForm)
                    break;

                decimal giaMoi;
                decimal thayDoi;

                lock (random)
                {
                    double bienDong =
                        random.NextDouble() * 0.006 - 0.003;

                    giaMoi = giaBTC * (1m + (decimal)bienDong);
                    thayDoi = giaMoi - giaBTC;
                    giaBTC = giaMoi;
                }

                DateTime thoiGian = DateTime.Now;

                CapNhatGiaoDien(giaMoi, thayDoi, thoiGian);
            }
        }

        private void CapNhatGiaoDien(
            decimal giaMoi,
            decimal thayDoi,
            DateTime thoiGian)
        {
            if (dangDongForm || IsDisposed || !IsHandleCreated)
                return;

            if (InvokeRequired)
            {
                try
                {
                    Invoke(new Action(() =>
                    {
                        if (!dangDongForm && !IsDisposed)
                        {
                            HienThiDuLieu(
                                giaMoi, thayDoi, thoiGian);
                        }
                    }));
                }
                catch (InvalidOperationException)
                {
                    // Bỏ qua khi form đang đóng hoặc handle không còn hợp lệ.
                }
            }
            else
            {
                if (!dangDongForm && !IsDisposed)
                {
                    HienThiDuLieu(giaMoi, thayDoi, thoiGian);
                }
            }
        }

        private void HienThiDuLieu(
            decimal giaMoi,
            decimal thayDoi,
            DateTime thoiGian)
        {
            if (dangDongForm || IsDisposed)
                return;

            lblBTCPrice.Text = giaMoi.ToString("N2") + " USD";

            if (thayDoi > 0)
                lblBTCPrice.ForeColor = Color.Green;
            else if (thayDoi < 0)
                lblBTCPrice.ForeColor = Color.Red;
            else
                lblBTCPrice.ForeColor = Color.Black;

            soLanDongBo++;

            lblLastUpdate.Text =
                "Lần cập nhật cuối: " +
                thoiGian.ToString("HH:mm:ss");

            lblSyncCount.Text =
                "Số lượt đồng bộ: " + soLanDongBo;

            string xuHuong;

            if (thayDoi > 0)
                xuHuong = "Tăng";
            else if (thayDoi < 0)
                xuHuong = "Giảm";
            else
                xuHuong = "Không đổi";

            int dong = dgvHistoryLog.Rows.Add(
                soLanDongBo,
                thoiGian.ToString("HH:mm:ss"),
                giaMoi.ToString("N2"),
                (thayDoi > 0 ? "+" : "") +
                    thayDoi.ToString("N2"),
                xuHuong
            );

            if (thayDoi > 0)
            {
                dgvHistoryLog.Rows[dong]
                    .DefaultCellStyle.ForeColor = Color.Green;
            }
            else if (thayDoi < 0)
            {
                dgvHistoryLog.Rows[dong]
                    .DefaultCellStyle.ForeColor = Color.Red;
            }
            else
            {
                dgvHistoryLog.Rows[dong]
                    .DefaultCellStyle.ForeColor = Color.Black;
            }

            if (dgvHistoryLog.Rows.Count > 0)
            {
                dgvHistoryLog.FirstDisplayedScrollingRowIndex =
                    dgvHistoryLog.Rows.Count - 1;
            }
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            dangDongForm = true;

            huyTheoDoi?.Cancel();

            base.OnFormClosing(e);
        }
    }
}
