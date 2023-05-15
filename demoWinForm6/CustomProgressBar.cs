namespace demoWinForm6
{
    public class CustomProgressBar : ProgressBar
    {
        public CustomProgressBar()
        {
            base.Value = 100;
            SetStyle(ControlStyles.UserPaint, true);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            Rectangle rect = ClientRectangle;

            using (SolidBrush brushBackground = new SolidBrush(Color.LightGray))
            {
                e.Graphics.FillRectangle(brushBackground, rect);
            }

            using (SolidBrush brushProgress = new SolidBrush(Color.Tomato))
            {
                float width = rect.Width * ((float)Value / Maximum);
                Rectangle progressRect = new Rectangle(rect.X, rect.Y, (int)width, rect.Height);
                e.Graphics.FillRectangle(brushProgress, progressRect);
            }
        }
    }

}
