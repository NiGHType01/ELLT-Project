

using System;
using System.Linq;
using System.Reflection;
using System.Collections;
using Microsoft.VisualBasic;
//Imports Wnlib
using WordNetClasses;
using System.Windows.Forms;
using System.IO;
using System.Threading;
using System.Drawing;

namespace WordNet.wnb
{
  
	public partial class StartForm : System.Windows.Forms.Form
	{
        int fontsize = 10;

        //set the location of WordNet 
         WN wnc = new  WN("..\\..\\WordNetDB\\dict\\");

        [STAThread]
		public static void Main(string[] args)
		{
			//Try
			Application.EnableVisualStyles();
			Application.DoEvents();
			Application.Run(new StartForm());
	

		}


		private void LoadAbout()
		{
			// load the 'about' text file
            System.IO.StreamReader myFile = new System.IO.StreamReader(MyPath() + "\\AboutApp.htm");
			string mystring = myFile.ReadToEnd();

			myFile.Close();

			showFeedback(mystring, false);
		}

        private void LoadRight()
        {

            // load the 'about' text file
            System.IO.StreamReader myFile = new System.IO.StreamReader(MyPath() + "\\RightSide.htm");
            string mystring = myFile.ReadToEnd();

            myFile.Close();

           
            webBrowser1.Document.OpenNew(false);
            webBrowser1.Document.Write(mystring);


        }

		private string MyPath()
		{
		
			string fullAppName = Assembly.GetExecutingAssembly().GetName().CodeBase;

			string FullAppPath = Path.GetDirectoryName(fullAppName);

			FullAppPath = Strings.Mid(FullAppPath, Strings.Len("file:\\\\"));


			#if (DEBUG == true)
			 FullAppPath = Strings.Mid(FullAppPath, 1, Strings.InStrRev(FullAppPath, "\\"));
			#endif


			return FullAppPath;
		}

	

		private void Overview()
		{
            //overview for 'search'
            string t = null;

			t = TextBox1.Text;
			Label2.Text = "Searches for " + t + ":";
			Label2.Visible = true;
			btnOverView.Visible = false;

	
			StatusBar1.Text = "Overview of " + t;
			Refresh();

			try {
		

				list = new ArrayList();

                String[] componentText = t.Split(' ');

                foreach (String searchingText in componentText)
                {
                    bool b = true;
                    wnc.OverviewFor(searchingText, "noun", ref b, ref bobj2, list);
                    btnNoun.Visible = b;

                    b = true;
                    wnc.OverviewFor(searchingText, "verb", ref b, ref bobj3, list);
                    btnverb.Visible = b;

                    b = true;
                    wnc.OverviewFor(searchingText, "adj", ref b, ref bobj4, list);
                    btnAdj.Visible = b;

                    b = true;
                    wnc.OverviewFor(searchingText, "adv", ref b, ref bobj5, list);
                    btnAdvrb.Visible = b;
                }

                TextBox1.Text = t;

                TextBox2.Text = "0";

           
            }
            catch (System.Exception ex) {
				MessageBox.Show(ex.Message);
			}

			FixDisplay();
		}

		private void DoSearch(Wnlib.Opt opt)
		{
			if (opt.sch.ptp.mnemonic == "OVERVIEW") {
				Overview();
				return;
			}


            HtmlViewer1.Document.OpenNew(false);
            HtmlViewer1.Visible = false;

			Refresh();

			list = new ArrayList();
			Wnlib.Search se = new Wnlib.Search(TextBox1.Text, true, opt.pos, opt.sch, int.Parse(TextBox2.Text));
			int a = se.buf.IndexOf("\n");
			if ((a >= 0)) {
				if ((a == 0)) {
					se.buf = se.buf.Substring(a + 1);
					a = se.buf.IndexOf("\n");
				}
				StatusBar1.Text = se.buf.Substring(0, a);
				se.buf = se.buf.Substring(a + 1);
			}
			//AddHistory(new wnHistory(Strings.Replace(TextBox1.Text, " ", "_"), opt, int.Parse(TextBox2.Text)));
			//        history.Add(New wnHistory(TextBox1.Text, opt, Integer.Parse(TextBox2.Text)))
			list.Add(se);
			if ((Wnlib.WNOpt.opt("-h").flag)) {
				help = new Wnlib.WNHelp(opt.sch, opt.pos).help;
			}
			FixDisplay();
		}

		public void CantFindDictionary()
		{
			Interaction.MsgBox("Error loading dictionary.  Click OK, then locate the WordNet dictionary.");

			//Menudictpath_Click(Nothing, Nothing)
		}

		ArrayList list = new ArrayList();

		string help = "";
		public void FixDisplay()
		{
			//Try
			pbobject = "";
			ShowResults();

			TextBox1.Focus();

			//            tb.useList(g, wnc.list, wnc.help, tmpstr)

			//Catch ex As Exception
			//MsgBox("FixDisplay: " & ex.Message)
			//End Try
		}

		//ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs)
		private void ShowResults()
		{
			string tmpstr = "";

			//Try
			if (list.Count == 0) {
				showFeedback("Search for " + TextBox1.Text + " returned 0 results.", true);
				return;
			}

			//Dim g As Graphics = e.Graphics()
			// this exists only for the type comparison
			//Dim tmptbox As WNBTBox.TBox = New WNBTBox.TBox(Nothing, Nothing)
			Overview tmptbox = new Overview();

			// this type comparison should be fixed, the tmptbox is a waste of resources
			//If Not Object.ReferenceEquals(PictureBox1.Tag.GetType, tmptbox.GetType) Then
			if ((!object.ReferenceEquals(pbobject.GetType(), tmptbox.GetType()))) {
				//Dim tb As WNBTBox.TBox = New WNBTBox.TBox(5, 5)
				Overview tb = new Overview();
				//TextBox3.Text = ""
				tb.useList(list, help, ref tmpstr);
				if ((help != null) & !string.IsNullOrEmpty(help)) {
					tmpstr = "<p>" + Strings.Replace(help, "vbcrlf", "<br />") + "</p>" + tmpstr;
				}
				tmpstr = Strings.Replace(tmpstr, Constants.vbLf, Constants.vbCrLf);
				tmpstr = Strings.Replace(tmpstr, Constants.vbCrLf, "", 1, 1);
				tmpstr = Strings.Replace(tmpstr, "_", " ");

				showFeedback(tmpstr, true);

				//HtmlViewer1.Document.close()
				//HtmlViewer1.Document.Write(tmpstr)
				//objdoc.write(tmpstr)
				//TextBox3.Text = tmpstr
				if (string.IsNullOrEmpty(tmpstr) | tmpstr == "<font color='green'><br />" + Constants.vbCr + " " + TextBox1.Text + " has no senses </font>") {
					showFeedback("Search for " + TextBox1.Text + " returned 0 results.", true);
				}
				HtmlViewer1.Visible = true;
				//TextBox1.Enabled = True
				//HtmlViewer1.SelectionLength = 0
				//Timer1.Enabled = False
				pbobject = tb;
			}

			TextBox1.Focus();
		
		}


  

		public Wnlib.SearchSet bobj2;
		public Wnlib.SearchSet bobj3;
		public Wnlib.SearchSet bobj4;
		public Wnlib.SearchSet bobj5;
		private void btnSearch_Click(System.Object sender, System.EventArgs e)
		{
			Overview();
			TextBox1.Focus();
		}

		private void TextBox1_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter) {
				e.Handled = true;
				btnSearch_Click(null, null);
			}
		}


		ArrayList opts = null;
		private void searchMenu_Click(object sender, System.EventArgs e)
		{
			// one of the options for button2_click was selected
			MenuItem mi = (MenuItem)sender;
			Wnlib.Opt opt = null;
			//= opts(mi.MenuItems.IndexOf(mi))
			int i = 0;
			string tmpstr = null;

            HtmlViewer1.Document.OpenNew(false);
            HtmlViewer1.Visible = false;

			tmpstr = mi.Text;
			tmpstr = Strings.Replace(tmpstr, "Syns", "Synonyms");
			tmpstr = Strings.Replace(tmpstr, " x ", " by ");
			tmpstr = Strings.Replace(tmpstr, "Freq:", "Frequency:");
			StatusBar1.Text = tmpstr;
			Refresh();

			for (i = 0; i <= mi.Parent.MenuItems.Count - 1; i++) {
				if (mi.Text == mi.Parent.MenuItems[i].Text) {
					opt = (Wnlib.Opt)opts[i];
				}
			}
			DoSearch(opt);
			btnOverView.Visible = true;

			//System.Windows.Forms.Application.DoEvents()
			HtmlViewer1.Visible = true;
            HtmlViewer1.BackColor = Color.AliceBlue;
            //TextBox1.Enabled = True
            //Timer1.Enabled = False
            Refresh();
		}

		private void MenuItem13_Click(System.Object sender, System.EventArgs e)
		{
            MenuItem mi = (MenuItem)sender;

            mi.Checked = !mi.Checked;

			showFeedback(rawFeedback, true);
		}

		private void MenuItem10_Click(System.Object sender, System.EventArgs e)
		{
            MenuItem mi = (MenuItem)sender;
            Wnlib.WNOpt.opt("-h").flag = mi.Checked == (!mi.Checked);
		}

		private void MenuItem11_Click(System.Object sender, System.EventArgs e)
		{
            MenuItem mi = (MenuItem)sender;
            mi.Checked = !mi.Checked;
			Wnlib.WNOpt.opt("-g").flag = !mi.Checked;
		}

		private void MenuItem9_Click(System.Object sender, System.EventArgs e)
		{
			Application.Exit();
		}

		private void MenuItem8_Click(System.Object sender, System.EventArgs e)
		{
          
            HtmlViewer1.Document.OpenNew(false);
            TextBox1.Text = "";
			Label2.Text = "";
			StatusBar1.Text = "ELLT";
			btnNoun.Visible = false;
			btnverb.Visible = false;
			btnAdj.Visible = false;
			btnAdvrb.Visible = false;
			btnOverView.Visible = false;
			btnSearch.Visible = true;

            LoadAbout();
		}


	

		private void MenuItem7_Click(System.Object sender, System.EventArgs e)
		{
			SaveFileDialog1.FileName = TextBox1.Text;
			if ((SaveFileDialog1.ShowDialog() == DialogResult.OK)) {
				StreamWriter f = new StreamWriter(SaveFileDialog1.FileName, false);

				f.Write(HtmlViewer1.Document.Body.InnerText);
				f.Close();
			}
		}

		private void showFeedback(string mystring, bool reformat)
		{
			if (reformat) {
				string headstyle = null;
				// format the size and font for tabe
				string nowraptbl = "<TABLE id=table1 width=100% border=0><br><TBODY><br><TR><br><TD>";
				//set the closeing of table 
				string closetbl = "</TD></TR></TBODY></TABLE>";

               string txtDesccolor=  ColorTranslator.ToHtml( btnDscrpColor.BackColor);
               string txtLinkword = ColorTranslator.ToHtml(btnlinkWord.BackColor);
               string txtDefColor = ColorTranslator.ToHtml(btnDefColor.BackColor);
               string txtQut = ColorTranslator.ToHtml(btnQuot.BackColor);
               string txtBackColor = ColorTranslator.ToHtml(btnBackColor.BackColor);

               headstyle = "<style>" + Constants.vbCrLf + "<!--" + Constants.vbCrLf + "body { background-color:" + txtBackColor + ";} " + Constants.vbCrLf + "*\t{ font-family:'Verdana'; font-size:" + fontsize + "pt }" + Constants.vbCrLf + ".Word   { color:" + txtLinkword + "; font-weight:bold }" + Constants.vbCrLf + ".Word a { color:" + txtLinkword + "; font-weight:bold; text-decoration: none }" + Constants.vbCrLf + ".Type { font-size: 12pt; color: #FFFFFF; font-weight: bold; background-color: #808080 }" + Constants.vbCrLf + ".Defn   { color:" + txtDefColor + "  }" + Constants.vbCrLf + ".Defn a { color: " + txtDefColor + "; text-decoration: none }" + Constants.vbCrLf + ".Quote   { color:" + txtQut + "; font-style:italic }" + Constants.vbCrLf + ".Quote a { color:" + txtDesccolor + "; text-decoration: none }" + Constants.vbCrLf + "a \t\t{ text-decoration: none }" + Constants.vbCrLf + "-->" + Constants.vbCrLf + "</style>" + Constants.vbCrLf + Constants.vbCrLf;

				mystring = Strings.Replace(mystring, Constants.vbCrLf, "<br>");
       
                HtmlViewer1.Document.OpenNew(false);
                HtmlViewer1.Document.Write(headstyle);

			
					HtmlViewer1.Document.Write(nowraptbl);

				HtmlViewer1.Document.Write(mystring);

				rawFeedback = mystring;

					HtmlViewer1.Document.Write(closetbl);
				//}
			} else {

               HtmlViewer1.Document.OpenNew(false);
                HtmlViewer1.Document.Write(mystring);
			}

			TextBox1.Focus();
		}
        
		private void HtmlViewer1_BeforeNavigate2(object sender, WebBrowserNavigatingEventArgs e) // AxSHDocVw.DWebBrowserEvents2_BeforeNavigate2Event e)
		{
			string tmpstr = null;
            tmpstr = e.Url.ToString();
			tmpstr = Strings.Replace(tmpstr, "about:blank", "");
			if (string.IsNullOrEmpty(tmpstr)) {
				return;
			}
            e.Cancel = true;

			StringWriter myWriter = new StringWriter();
			// Decode the encoded string.

			TextBox1.Text = Strings.Replace(tmpstr, "%20", " ").Replace("about:", "");
			btnSearch_Click(null, null);
		}


        private void WebBrowser_BeforeNavigate(object sender, WebBrowserNavigatingEventArgs e) // AxSHDocVw.DWebBrowserEvents2_BeforeNavigate2Event e)
        {
            string tmpstr = null;
            tmpstr = e.Url.ToString();
            tmpstr = Strings.Replace(tmpstr, "about:blank", "");
            if (string.IsNullOrEmpty(tmpstr))
            {
                return;
            }
            e.Cancel = true;

            StringWriter myWriter = new StringWriter();
            // Decode the encoded string.

            TextBox1.Text = Strings.Replace(tmpstr, "%20", " ").Replace("about:", "");
            btnSearch_Click(null, null);
        }

		private void btnClick(System.Object sender, System.EventArgs e)
		{
			// handles noun, verb, adj, adverb click for context menu
			Button b = (Button)sender;
			Wnlib.SearchSet ss = null;
			//= bobj2
			string btext = b.Text;

			if (btext == "Adjective") {
				btext = "Adj";
			}

			switch (btext) {
				case "Noun":
					ss = (Wnlib.SearchSet)bobj2;

					break;
				case "Verb":
					ss = (Wnlib.SearchSet)bobj3;

					break;
				case "Adj":
					ss = (Wnlib.SearchSet)bobj4;

					break;
				case "Adverb":
					ss = (Wnlib.SearchSet)bobj5;
					break;
			}

			Wnlib.PartOfSpeech pos = Wnlib.PartOfSpeech.of(btext.ToLower());
			int i = 0;
			opts = new ArrayList();
			ContextMenu cm = new ContextMenu();
			ArrayList tmplst = new ArrayList();

			for (i = 0; i <= Wnlib.Opt.Count - 1; i++) {
                Wnlib.Opt opt = Wnlib.Opt.at(i);

				//Try ' TODO: fix problem with adjective menu
				if (ss[opt.sch.ptp.ident] & object.ReferenceEquals(opt.pos, pos)) {
					if (tmplst.IndexOf(opt.label) == -1 & opt.label != "Grep") {
						MenuItem mi = new MenuItem();
						// (opt.label, AddressOf searchMenu_Click)
						mi.Text = opt.label;
						mi.Click += searchMenu_Click;
						opts.Add(opt);
						cm.MenuItems.Add(mi);

						tmplst.Add(opt.label);
					}
				}
				//Catch
				//End Try
			}

			cm.Show(b.Parent, new System.Drawing.Point(b.Left, b.Bottom));
			//Point(b.Left, b.Bottom))
		}

		


        private void meuUseApp_Click(object sender, EventArgs e)
        {//about the application
            System.IO.StreamReader myFile = new System.IO.StreamReader(MyPath() + "\\ApplicatopnHelp.txt");
            string mystring = myFile.ReadToEnd();

            myFile.Close();

            mystring = Strings.Replace(mystring, Constants.vbCrLf, "<br>");
            showFeedback(mystring, true);
        }

        private void menuAbout_Click(object sender, EventArgs e)
        {
            LoadAbout();
        }

        private void btnverb_Click(object sender, EventArgs e)
        {
            btnClick(sender, null);
        }

        private void btnAdj_Click(object sender, EventArgs e)
        {
            btnClick(sender, null);
        }
        //overviw
        private void btnAdvrb_Click(object sender, EventArgs e)
        {
            btnClick(sender, null);
        }

        private void btnOverView_Click(object sender, EventArgs e)
        {
            	Overview();
        }


        private void button2_Click(object sender, EventArgs e)
        {
            //decrease font size
            if (fontsize > 1)
                fontsize--;
            Overview();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //increase font size
            fontsize++;
            Overview();
        }

        private void button3_Click(object sender, EventArgs e)
        {
        //print document 
            HtmlViewer1.ShowPrintPreviewDialog();
        }

        private void menuItem2_Click(object sender, EventArgs e)
        {
            HtmlViewer1.ShowPrintPreviewDialog();
        }

        private void StartForm_Load(object sender, EventArgs e)
        {
            LoadAbout();
            LoadRight();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            webBrowser1.ShowPrintPreviewDialog();
        }

        private void btnlinkWord_Click(object sender, EventArgs e)
        {

            colorDialog1.ShowDialog(this);

            btnlinkWord.BackColor = colorDialog1.Color;
            Overview();

        }

        private void btnDscrpColor_Click(object sender, EventArgs e)
        {
            colorDialog1.ShowDialog(this);

            btnDscrpColor.BackColor = colorDialog1.Color;
            Overview();
        }

        private void btnDefColor_Click(object sender, EventArgs e)
        {
            colorDialog1.ShowDialog(this);

            btnDefColor.BackColor = colorDialog1.Color;
            Overview();
        }

        private void btnQuot_Click(object sender, EventArgs e)
        {
            colorDialog1.ShowDialog(this);
            btnQuot.BackColor = colorDialog1.Color;
            Overview();

        }

        private void btnBackColor_Click(object sender, EventArgs e)
        {

            colorDialog1.ShowDialog(this);
            btnBackColor.BackColor = colorDialog1.Color;
            Overview();
        }

        
    }
}
