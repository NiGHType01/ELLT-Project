using System;
using System.Linq;
using System.Reflection;
using System.Collections;
using Microsoft.VisualBasic;


using WordNetClasses;
using System.Windows.Forms;
using System.IO;
using System.Threading;

namespace WordNet.wnb
{
    public partial class StartForm : System.Windows.Forms.Form
    {
        internal System.Windows.Forms.Label Label3;
        internal System.Windows.Forms.Label Label2;
        private System.Windows.Forms.MenuItem MenuItem7;
        private System.Windows.Forms.Button btnverb;
        private System.Windows.Forms.Button btnNoun;
        private System.Windows.Forms.Button btnOverView;
        private System.Windows.Forms.Button btnAdvrb;
        private System.Windows.Forms.Button btnAdj;
        internal System.Windows.Forms.MenuItem MenuItem17;
        internal System.Windows.Forms.StatusBar StatusBar1;
        internal System.Windows.Forms.MenuItem MenuItem4;
        internal System.Windows.Forms.Label Label1;
        internal System.Windows.Forms.MenuItem MenuItem1;
        internal System.Windows.Forms.MenuItem MenuItem6;
        private System.Windows.Forms.MenuItem meuUseApp;
        private System.Windows.Forms.MenuItem menuAbout;
        private System.Windows.Forms.MenuItem MenuItem9;
        private System.Windows.Forms.MenuItem MenuItem8;
        internal System.Windows.Forms.TextBox TextBox1;
        internal System.Windows.Forms.TextBox TextBox2;
        internal System.Windows.Forms.SaveFileDialog SaveFileDialog1;
        internal System.Windows.Forms.MainMenu MainMenu1;
        private System.Windows.Forms.Button btnSearch;


     
        ArrayList history = new ArrayList();
        object pbobject = new object();
        public int maxhistory = 10;
        internal System.Windows.Forms.WebBrowser HtmlViewer1;
        // html without word wrap escaping table
        public string rawFeedback;

        #region " Windows Form Designer generated code "

        public StartForm() : base()
        {

            Load += StartForm_Load;

            //This call is required by the Windows Form Designer.
            InitializeComponent();
            HtmlViewer1.Navigate("about:blank");
            //HtmlViewer1.Document.OpenNew(false);
            //TODO: re-implement silent
            //HtmlViewer1.Silent = True
            //Add any initialization after the InitializeComponent() call
        }

        //Form overrides dispose to clean up the component list.
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if ((components != null))
                {
                    components.Dispose();
                }
            }
            base.Dispose(disposing);
        }

        //Required by the Windows Form Designer

        private System.ComponentModel.IContainer components;
        //NOTE: The following procedure is required by the Windows Form Designer
        //It can be modified using the Windows Form Designer.  
        //Do not modify it using the code editor.
        //[System.Diagnostics.DebuggerStepThrough()]
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(StartForm));
            this.btnSearch = new System.Windows.Forms.Button();
            this.MainMenu1 = new System.Windows.Forms.MainMenu(this.components);
            this.MenuItem1 = new System.Windows.Forms.MenuItem();
            this.MenuItem6 = new System.Windows.Forms.MenuItem();
            this.menuItem2 = new System.Windows.Forms.MenuItem();
            this.MenuItem7 = new System.Windows.Forms.MenuItem();
            this.MenuItem8 = new System.Windows.Forms.MenuItem();
            this.MenuItem9 = new System.Windows.Forms.MenuItem();
            this.MenuItem4 = new System.Windows.Forms.MenuItem();
            this.meuUseApp = new System.Windows.Forms.MenuItem();
            this.MenuItem17 = new System.Windows.Forms.MenuItem();
            this.menuAbout = new System.Windows.Forms.MenuItem();
            this.SaveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.TextBox2 = new System.Windows.Forms.TextBox();
            this.TextBox1 = new System.Windows.Forms.TextBox();
            this.Label1 = new System.Windows.Forms.Label();
            this.StatusBar1 = new System.Windows.Forms.StatusBar();
            this.btnAdj = new System.Windows.Forms.Button();
            this.btnAdvrb = new System.Windows.Forms.Button();
            this.btnOverView = new System.Windows.Forms.Button();
            this.btnNoun = new System.Windows.Forms.Button();
            this.btnverb = new System.Windows.Forms.Button();
            this.Label2 = new System.Windows.Forms.Label();
            this.Label3 = new System.Windows.Forms.Label();
            this.HtmlViewer1 = new System.Windows.Forms.WebBrowser();
            this.button1 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.webBrowser1 = new System.Windows.Forms.WebBrowser();
            this.button4 = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.button5 = new System.Windows.Forms.Button();
            this.btnlinkWord = new System.Windows.Forms.Button();
            this.btnQuot = new System.Windows.Forms.Button();
            this.btnDefColor = new System.Windows.Forms.Button();
            this.btnDscrpColor = new System.Windows.Forms.Button();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.btnBackColor = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnSearch
            // 
            this.btnSearch.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSearch.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnSearch.Location = new System.Drawing.Point(846, 6);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(56, 23);
            this.btnSearch.TabIndex = 13;
            this.btnSearch.Text = "Search";
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // MainMenu1
            // 
            this.MainMenu1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.MenuItem1,
            this.MenuItem4});
            // 
            // MenuItem1
            // 
            this.MenuItem1.Index = 0;
            this.MenuItem1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.MenuItem6,
            this.menuItem2,
            this.MenuItem7,
            this.MenuItem8,
            this.MenuItem9});
            this.MenuItem1.Text = "File";
            // 
            // MenuItem6
            // 
            this.MenuItem6.Index = 0;
            this.MenuItem6.Text = "-";
            // 
            // menuItem2
            // 
            this.menuItem2.Index = 1;
            this.menuItem2.Text = "Print Document";
            this.menuItem2.Click += new System.EventHandler(this.menuItem2_Click);
            // 
            // MenuItem7
            // 
            this.MenuItem7.Index = 2;
            this.MenuItem7.Text = "Save to File";
            this.MenuItem7.Click += new System.EventHandler(this.MenuItem7_Click);
            // 
            // MenuItem8
            // 
            this.MenuItem8.Index = 3;
            this.MenuItem8.Text = "Clear Search";
            this.MenuItem8.Click += new System.EventHandler(this.MenuItem8_Click);
            // 
            // MenuItem9
            // 
            this.MenuItem9.Index = 4;
            this.MenuItem9.Text = "Exit";
            this.MenuItem9.Click += new System.EventHandler(this.MenuItem9_Click);
            // 
            // MenuItem4
            // 
            this.MenuItem4.Index = 1;
            this.MenuItem4.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.meuUseApp,
            this.MenuItem17,
            this.menuAbout});
            this.MenuItem4.Text = "Help";
            // 
            // meuUseApp
            // 
            this.meuUseApp.Index = 0;
            this.meuUseApp.Text = "Use Application";
            this.meuUseApp.Click += new System.EventHandler(this.meuUseApp_Click);
            // 
            // MenuItem17
            // 
            this.MenuItem17.Index = 1;
            this.MenuItem17.Text = "-";
            // 
            // menuAbout
            // 
            this.menuAbout.Index = 2;
            this.menuAbout.Text = "About Application";
            this.menuAbout.Click += new System.EventHandler(this.menuAbout_Click);
            // 
            // SaveFileDialog1
            // 
            this.SaveFileDialog1.Filter = "Text files (*.txt)|*.txt";
            // 
            // TextBox2
            // 
            this.TextBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.TextBox2.Location = new System.Drawing.Point(1088, 8);
            this.TextBox2.Name = "TextBox2";
            this.TextBox2.Size = new System.Drawing.Size(40, 20);
            this.TextBox2.TabIndex = 8;
            this.TextBox2.Text = "0";
            this.TextBox2.Visible = false;
            // 
            // TextBox1
            // 
            this.TextBox1.AcceptsReturn = true;
            this.TextBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.TextBox1.Location = new System.Drawing.Point(80, 8);
            this.TextBox1.Name = "TextBox1";
            this.TextBox1.Size = new System.Drawing.Size(760, 20);
            this.TextBox1.TabIndex = 1;
            this.TextBox1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TextBox1_KeyDown);
            // 
            // Label1
            // 
            this.Label1.Location = new System.Drawing.Point(0, 8);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(80, 23);
            this.Label1.TabIndex = 0;
            this.Label1.Text = "Search Word:";
            // 
            // StatusBar1
            // 
            this.StatusBar1.Location = new System.Drawing.Point(0, 644);
            this.StatusBar1.Name = "StatusBar1";
            this.StatusBar1.Size = new System.Drawing.Size(1136, 22);
            this.StatusBar1.TabIndex = 9;
            this.StatusBar1.Text = "ELLT";
            // 
            // btnAdj
            // 
            this.btnAdj.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnAdj.Location = new System.Drawing.Point(401, 33);
            this.btnAdj.Name = "btnAdj";
            this.btnAdj.Size = new System.Drawing.Size(64, 23);
            this.btnAdj.TabIndex = 5;
            this.btnAdj.Text = "Adjective";
            this.btnAdj.Visible = false;
            this.btnAdj.Click += new System.EventHandler(this.btnAdj_Click);
            // 
            // btnAdvrb
            // 
            this.btnAdvrb.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnAdvrb.Location = new System.Drawing.Point(473, 33);
            this.btnAdvrb.Name = "btnAdvrb";
            this.btnAdvrb.Size = new System.Drawing.Size(48, 23);
            this.btnAdvrb.TabIndex = 6;
            this.btnAdvrb.Text = "Adverb";
            this.btnAdvrb.Visible = false;
            this.btnAdvrb.Click += new System.EventHandler(this.btnAdvrb_Click);
            // 
            // btnOverView
            // 
            this.btnOverView.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOverView.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnOverView.Location = new System.Drawing.Point(769, 33);
            this.btnOverView.Name = "btnOverView";
            this.btnOverView.Size = new System.Drawing.Size(75, 23);
            this.btnOverView.TabIndex = 15;
            this.btnOverView.Text = "Overview";
            this.btnOverView.Visible = false;
            this.btnOverView.Click += new System.EventHandler(this.btnOverView_Click);
            // 
            // btnNoun
            // 
            this.btnNoun.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnNoun.Location = new System.Drawing.Point(305, 33);
            this.btnNoun.Name = "btnNoun";
            this.btnNoun.Size = new System.Drawing.Size(40, 23);
            this.btnNoun.TabIndex = 3;
            this.btnNoun.Text = "Noun";
            this.btnNoun.Visible = false;
            this.btnNoun.Click += new System.EventHandler(this.btnClick);
            // 
            // btnverb
            // 
            this.btnverb.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnverb.Location = new System.Drawing.Point(353, 33);
            this.btnverb.Name = "btnverb";
            this.btnverb.Size = new System.Drawing.Size(40, 23);
            this.btnverb.TabIndex = 4;
            this.btnverb.Text = "Verb";
            this.btnverb.Visible = false;
            this.btnverb.Click += new System.EventHandler(this.btnverb_Click);
            // 
            // Label2
            // 
            this.Label2.Location = new System.Drawing.Point(1, 33);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(296, 23);
            this.Label2.TabIndex = 2;
            // 
            // Label3
            // 
            this.Label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Label3.Location = new System.Drawing.Point(1024, 8);
            this.Label3.Name = "Label3";
            this.Label3.Size = new System.Drawing.Size(100, 23);
            this.Label3.TabIndex = 7;
            this.Label3.Text = "Senses:";
            this.Label3.Visible = false;
            // 
            // HtmlViewer1
            // 
            this.HtmlViewer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.HtmlViewer1.Location = new System.Drawing.Point(4, 114);
            this.HtmlViewer1.MinimumSize = new System.Drawing.Size(20, 20);
            this.HtmlViewer1.Name = "HtmlViewer1";
            this.HtmlViewer1.Size = new System.Drawing.Size(862, 530);
            this.HtmlViewer1.TabIndex = 19;
            this.HtmlViewer1.Navigating += new System.Windows.Forms.WebBrowserNavigatingEventHandler(this.HtmlViewer1_BeforeNavigate2);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(52, 15);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(35, 23);
            this.button1.TabIndex = 21;
            this.button1.Text = "+";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button3
            // 
            this.button3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button3.ForeColor = System.Drawing.Color.Blue;
            this.button3.Location = new System.Drawing.Point(1024, 27);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(104, 23);
            this.button3.TabIndex = 22;
            this.button3.Text = "Print result";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // webBrowser1
            // 
            this.webBrowser1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.webBrowser1.Location = new System.Drawing.Point(872, 114);
            this.webBrowser1.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowser1.Name = "webBrowser1";
            this.webBrowser1.Size = new System.Drawing.Size(256, 530);
            this.webBrowser1.TabIndex = 19;
            this.webBrowser1.Url = new System.Uri("", System.UriKind.Relative);
            this.webBrowser1.Navigating += new System.Windows.Forms.WebBrowserNavigatingEventHandler(this.WebBrowser_BeforeNavigate);
            // 
            // button4
            // 
            this.button4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button4.ForeColor = System.Drawing.Color.Blue;
            this.button4.Location = new System.Drawing.Point(1024, 49);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(104, 23);
            this.button4.TabIndex = 22;
            this.button4.Text = "Print Commets";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.button5);
            this.groupBox2.Controls.Add(this.button1);
            this.groupBox2.ForeColor = System.Drawing.Color.Blue;
            this.groupBox2.Location = new System.Drawing.Point(678, 64);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(204, 44);
            this.groupBox2.TabIndex = 21;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Font Size";
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(103, 15);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(35, 23);
            this.button5.TabIndex = 22;
            this.button5.Text = "-";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button2_Click);
            // 
            // btnlinkWord
            // 
            this.btnlinkWord.BackColor = System.Drawing.Color.MediumSlateBlue;
            this.btnlinkWord.ForeColor = System.Drawing.Color.Black;
            this.btnlinkWord.Location = new System.Drawing.Point(12, 64);
            this.btnlinkWord.Name = "btnlinkWord";
            this.btnlinkWord.Size = new System.Drawing.Size(84, 23);
            this.btnlinkWord.TabIndex = 21;
            this.btnlinkWord.UseVisualStyleBackColor = false;
            this.btnlinkWord.Click += new System.EventHandler(this.btnlinkWord_Click);
            // 
            // btnQuot
            // 
            this.btnQuot.BackColor = System.Drawing.Color.Aquamarine;
            this.btnQuot.ForeColor = System.Drawing.Color.Black;
            this.btnQuot.Location = new System.Drawing.Point(362, 64);
            this.btnQuot.Name = "btnQuot";
            this.btnQuot.Size = new System.Drawing.Size(103, 23);
            this.btnQuot.TabIndex = 21;
            this.btnQuot.UseVisualStyleBackColor = false;
            this.btnQuot.Click += new System.EventHandler(this.btnQuot_Click);
            // 
            // btnDefColor
            // 
            this.btnDefColor.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.btnDefColor.ForeColor = System.Drawing.Color.Black;
            this.btnDefColor.Location = new System.Drawing.Point(121, 64);
            this.btnDefColor.Name = "btnDefColor";
            this.btnDefColor.Size = new System.Drawing.Size(103, 23);
            this.btnDefColor.TabIndex = 21;
            this.btnDefColor.UseVisualStyleBackColor = false;
            this.btnDefColor.Click += new System.EventHandler(this.btnDefColor_Click);
            // 
            // btnDscrpColor
            // 
            this.btnDscrpColor.BackColor = System.Drawing.Color.Fuchsia;
            this.btnDscrpColor.ForeColor = System.Drawing.Color.Black;
            this.btnDscrpColor.Location = new System.Drawing.Point(242, 64);
            this.btnDscrpColor.Name = "btnDscrpColor";
            this.btnDscrpColor.Size = new System.Drawing.Size(103, 23);
            this.btnDscrpColor.TabIndex = 21;
            this.btnDscrpColor.UseVisualStyleBackColor = false;
            this.btnDscrpColor.Click += new System.EventHandler(this.btnDscrpColor_Click);
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(16, 90);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(80, 18);
            this.label4.TabIndex = 23;
            this.label4.Text = "Word Color";
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(362, 90);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(103, 18);
            this.label5.TabIndex = 24;
            this.label5.Text = "Quatation Color";
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(242, 90);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(103, 18);
            this.label6.TabIndex = 25;
            this.label6.Text = "Descrption Color";
            // 
            // label7
            // 
            this.label7.Location = new System.Drawing.Point(121, 90);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(103, 18);
            this.label7.TabIndex = 26;
            this.label7.Text = "Definition Color";
            // 
            // btnBackColor
            // 
            this.btnBackColor.BackColor = System.Drawing.Color.White;
            this.btnBackColor.ForeColor = System.Drawing.Color.Black;
            this.btnBackColor.Location = new System.Drawing.Point(473, 62);
            this.btnBackColor.Name = "btnBackColor";
            this.btnBackColor.Size = new System.Drawing.Size(103, 23);
            this.btnBackColor.TabIndex = 21;
            this.btnBackColor.UseVisualStyleBackColor = false;
            this.btnBackColor.Click += new System.EventHandler(this.btnBackColor_Click);
            // 
            // label8
            // 
            this.label8.Location = new System.Drawing.Point(473, 90);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(103, 18);
            this.label8.TabIndex = 24;
            this.label8.Text = "Back Color";
            // 
            // StartForm
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(1136, 666);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnOverView);
            this.Controls.Add(this.btnAdvrb);
            this.Controls.Add(this.btnBackColor);
            this.Controls.Add(this.btnQuot);
            this.Controls.Add(this.btnlinkWord);
            this.Controls.Add(this.btnDefColor);
            this.Controls.Add(this.btnAdj);
            this.Controls.Add(this.btnDscrpColor);
            this.Controls.Add(this.btnverb);
            this.Controls.Add(this.btnNoun);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.webBrowser1);
            this.Controls.Add(this.HtmlViewer1);
            this.Controls.Add(this.TextBox2);
            this.Controls.Add(this.TextBox1);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.StatusBar1);
            this.Controls.Add(this.Label3);
            this.Controls.Add(this.Label2);
            this.Controls.Add(this.Label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Menu = this.MainMenu1;
            this.Name = "StartForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ELLT";
            this.Load += new System.EventHandler(this.StartForm_Load);
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Button button1;
        private Button button3;
        private MenuItem menuItem2;
        internal WebBrowser webBrowser1;
        private Button button4;
        private GroupBox groupBox2;
        private Button button5;
        private Button btnDscrpColor;
        private Button btnlinkWord;
        private Button btnDefColor;
        private Button btnQuot;
        private ColorDialog colorDialog1;
        internal Label label4;
        internal Label label5;
        internal Label label6;
        internal Label label7;
        private Button btnBackColor;
        internal Label label8;
    }
}
