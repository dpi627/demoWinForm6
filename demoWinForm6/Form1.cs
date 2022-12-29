using Serilog;
using System.Diagnostics;

namespace demoWinForm6
{
    public partial class Form1 : Form
    {
        Form2 f;
        Random r = new Random();
        int itemCouns = 0;
        int pInit = 0;
        int pStep = 0;
        int sleep = 2000;
        public Form1()
        {
            InitializeComponent();

            f = new Form2();

            Log.Information("Form 1 init");

            itemCouns = r.Next(3, 6);
            AddLog($"Test Round: {itemCouns}");
            pInit = 100 % itemCouns;
            pStep = 100 / itemCouns;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            button2_Click(this, new EventArgs());
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AddLog(textBox1.Text);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            f.Visible = (f.Visible) ? false : true;

            if (f.Visible)
            {
                f.Location = new Point(this.Location.X + this.Width, this.Location.Y);
                f.Height = this.Height;
            }
        }

        private void AddLog(object log)
        {
            f.textBox1.AppendText( $"{log}{Environment.NewLine}");
        }



        private void StartProgress()
        {
            progressBar1.Value = pInit;
            for (int i = 0; i < itemCouns; i++)
            {
                var watch = Stopwatch.StartNew();
                doSomething();
                AddLog($"{i} {watch.Elapsed}");
                progressBar1.Value += pStep;
            }
        }
        private async Task StartProgressAsync()
        {
            progressBar1.Value = pInit;
            for (int i = 0; i < itemCouns; i++)
            {
                var watch = Stopwatch.StartNew();
                await doSomethingAsync();
                AddLog($"{i} {watch.Elapsed}");
                progressBar1.Value += pStep;
            }
        }

        private async Task StartProgress2Async()
        {
            List<Task<string>> Tasks = new List<Task<string>>();

            progressBar1.Value = pInit;
            for (int i = 0; i < itemCouns; i++)
            {
                var watch = Stopwatch.StartNew();
                Tasks.Add(Task.Run(() => doSomething2Async(i)));
                AddLog($"{i} {watch.Elapsed}");
                progressBar1.Value += pStep;
            }

            await Task.WhenAll( Tasks);
            
        }

        private async Task StartProgress3Async()
        {
            List<Task<string>> Tasks = new List<Task<string>>();

            progressBar1.Value = pInit;
            for (int i = 0; i < itemCouns; i++)
            {
                Tasks.Add(doSomething2Async(i));
                progressBar1.Value += pStep;
            }

            var result = await Task.WhenAll(Tasks);
            foreach (string s in result)
            {
                AddLog(s);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var watch = Stopwatch.StartNew();
            StartProgress();
            AddLog($"Sync Finished: {watch.Elapsed}");
        }

        private async void button4_Click(object sender, EventArgs e)
        {
            var watch = Stopwatch.StartNew();
            await StartProgressAsync();
            AddLog($"Async Finished: {watch.Elapsed}");
        }

        private async void button5_Click(object sender, EventArgs e)
        {
            var watch = Stopwatch.StartNew();
            await StartProgress2Async();
            AddLog($"Async 2 Finished: {watch.Elapsed}");
        }

        private void doSomething()
        {
            Thread.Sleep(sleep);
        }

        private async Task doSomethingAsync()
        {
            await Task.Delay(sleep);
        }

        private async Task<string> doSomething2Async(int i)
        {
            var watch = Stopwatch.StartNew();
            await Task.Delay(sleep);
            return $"{i} {watch.Elapsed}";
        }

        private void Form1_LocationChanged(object sender, EventArgs e)
        {
            if (f.Visible)
            {
                f.Location = new Point(this.Location.X + this.Width, this.Location.Y);
                f.Height = this.Height;
            }
        }

        private async void button6_Click(object sender, EventArgs e)
        {
            var watch = Stopwatch.StartNew();
            await StartProgress3Async();
            AddLog($"Async 3 Finished: {watch.Elapsed}");
        }
    }
}