using System;
using System.Drawing;
using System.Windows.Forms;
using System.Drawing.Printing;

namespace LicenseGenerator
{
    public partial class F62_SoftwareAgreement : Form
    {
        private int i = 0;
        private int pagesPrinted = 0;
        private Image img;
        
        
        public F62_SoftwareAgreement()
        {
            InitializeComponent();
        }

        private void F62_SoftwareAgreement_Load(object sender, EventArgs e)
        {
            PrintDocument pd = new PrintDocument();
            pd.PrintPage += new PrintPageEventHandler(pd_PrintPage);
            PrintDialog ptd = new PrintDialog();
            ptd.Document = pd;
            DialogResult result = ptd.ShowDialog();
            if (result == DialogResult.OK)
            {
                pd.Print();
            }
        }
        
        private void pd_PrintPage(object sender, PrintPageEventArgs ev)
        {
            string date = DateTime.Now.ToShortDateString();
            int linedrop = 150;
            int count = 0;
            int linesPerpage = 50;
            int lineNo = this.pagesPrinted * linesPerpage;
            int pageNo = pagesPrinted + 1;
            double NumPages = Math.Ceiling(((i - 1) / 50.0));
            if (NumPages == 0) { NumPages = 1; }

            Pen pen = new Pen(Color.Black);
            pen.Width = 1;
            Font arial = new Font("arial", 10, FontStyle.Regular);
            Font title = new Font("arial", 30, FontStyle.Regular);
            Font heading = new Font("arial", 16, FontStyle.Bold);
            Font leaders = new Font("arial", 12, FontStyle.Bold);
            Font arial7 = new Font("arial", 7, FontStyle.Regular);

            if (g.productLine == "MTP")
            {
                img = System.Drawing.Image.FromFile(@"c:\zygo license generator\metropro.jpg");
            }
            if (g.productLine == "MX")
            {
                img = System.Drawing.Image.FromFile(@"c:\zygo license generator\mx.jpg");
            }
            if (g.productLine == "ZMP")
            {
                img = System.Drawing.Image.FromFile(@"c:\zygo license generator\zemaps.jpg");
            }

            
            while (count < linesPerpage && lineNo < i)
            {
                lineNo++;
                count++;
                linedrop = linedrop + 25;
            }
            int nextpar = 100;
            int drop = 12;
            ev.Graphics.DrawString("ZYGO SOFTWARE LICENSE AGREEMENT", arial7, Brushes.Black, 50, nextpar);
            nextpar = nextpar + drop + drop;
            ev.Graphics.DrawString("PLEASE READ THIS SOFTWARE LICENSE AGREEMENT CAREFULLY BEFORE DOWNLOADING OR USING THE SOFTWARE.", arial7, Brushes.Black, 50, nextpar);
            nextpar = nextpar + drop + drop;
            ev.Graphics.DrawString(@"BY CLICKING ON THE ""ACCEPT"" BUTTON, OPENING THE PACKAGE, DOWNLOADING THE PRODUCT, OR USING THE EQUIPMENT THAT CONTAINS", arial7, Brushes.Black, 50, nextpar);
            nextpar = nextpar + drop;
            ev.Graphics.DrawString("THIS PRODUCT, YOU ARE CONSENTING TO BE BOUND BY THIS AGREEMENT.  IF YOU DO NOT AGREE TO ALL OF THE TERMS OF THIS AGREEMENT,", arial7, Brushes.Black, 50, nextpar);
            nextpar = nextpar + drop;
            ev.Graphics.DrawString(@"CLICK THE ""DO NOT ACCEPT"" BUTTON AND THE INSTALLATION PROCESS WILL NOT CONTINUE, RETURN THE PRODUCT TO THE PLACE OF ", arial7, Brushes.Black, 50, nextpar);
            nextpar = nextpar + drop;
            ev.Graphics.DrawString("PURCHASE FOR A FULL REFUND, OR DO NOT DOWNLOAD THE PRODUCT.", arial7, Brushes.Black, 50, nextpar);
            nextpar = nextpar + drop + drop;
            ev.Graphics.DrawString(@"Single User License Grant:  Zygo Corporation (""Zygo"") and its suppliers grant to Customer (""Customer"") a nonexclusive and nontransferable license to use the Zygo", arial7, Brushes.Black, 50, nextpar);
            nextpar = nextpar + drop;
            ev.Graphics.DrawString(@"software (""Software"") solely on a single computer owned or leased by Customer or otherwise embedded in equipment provided by Zygo.  Customer may not network", arial7, Brushes.Black, 50, nextpar);
            nextpar = nextpar + drop;
            ev.Graphics.DrawString("this software or use it on more than one computer or computer terminal at the same time.", arial7, Brushes.Black, 50, nextpar);
            nextpar = nextpar + drop + drop;
            ev.Graphics.DrawString("Customer may make one (1) archival copy of the Software provided Customer affixes to such copy all copyright, confidentiality, and proprietary notices that appear", arial7, Brushes.Black, 50, nextpar);
            nextpar = nextpar + drop;
            ev.Graphics.DrawString("on the original.", arial7, Brushes.Black, 50, nextpar);
            nextpar = nextpar + drop + drop;
            ev.Graphics.DrawString("EXCEPT AS EXPRESSLY AUTHORIZED ABOVE, CUSTOMER SHALL NOT:  COPY, IN WHOLE OR IN PART, SOFTWARE OR DOCUMENTATION; MODIFY THE", arial7, Brushes.Black, 50, nextpar);
            nextpar = nextpar + drop;
            ev.Graphics.DrawString("SOFTWARE; REVERSE COMPILE OR REVERSE ASSEMBLE ALL OR ANY PORTION OF THE SOFTWARE; OR RENT, LEASE, DISTRIBUTE, SELL, OR CREATE", arial7, Brushes.Black, 50, nextpar);
            nextpar = nextpar + drop;
            ev.Graphics.DrawString("DERIVATIVE WORKS OF THE SOFTWARE.", arial7, Brushes.Black, 50, nextpar);
            nextpar = nextpar + drop + drop;
            ev.Graphics.DrawString("Customer agrees that aspects of the licensed materials, including hte specific design and structure of individual programs, constitute trade secrets and/or copyrighted", arial7, Brushes.Black, 50, nextpar);
            nextpar = nextpar + drop;
            ev.Graphics.DrawString("material of Zygo.  Customer agrees to not disclose, provide, or otherwise make available such trade secrets or copyrighted material in any form to any third party without", arial7, Brushes.Black, 50, nextpar);
            nextpar = nextpar + drop;
            ev.Graphics.DrawString("prior written consent of Zygo.  Customer agrees to implement reasonable security measures to protect such trade secrets and copyrighted material.  Title to Software", arial7, Brushes.Black, 50, nextpar);
            nextpar = nextpar + drop;
            ev.Graphics.DrawString("and documentation shall remain solely with Zygo.", arial7, Brushes.Black, 50, nextpar);
            nextpar = nextpar + drop + drop;
            ev.Graphics.DrawString("LIMITED WARRANTY. Zygo warrants that for a period of ninety (90) days from the date of shipment from Zygo:  (i) the media on which the Software is furnished will be", arial7, Brushes.Black, 50, nextpar);
            nextpar = nextpar + drop;
            ev.Graphics.DrawString("free of defects in materials and workmanship under normal use; and (ii) the Software substantially conforms to its published specifications.  Except for the foregoing, the ", arial7, Brushes.Black, 50, nextpar);
            nextpar = nextpar + drop;
            ev.Graphics.DrawString("Software is provided AS IS.  This limited warranty extends only to Customer as the original licensee.  Customer's exclusive remedy and the entire liability of Zygo and its", arial7, Brushes.Black, 50, nextpar);
            nextpar = nextpar + drop;
            ev.Graphics.DrawString("suppliers under this limited warranty will be, at Zygo or its service center's option, repair, replacement, or refund of the Software if reported (or, upon request, returned)", arial7, Brushes.Black, 50, nextpar);
            nextpar = nextpar + drop;
            ev.Graphics.DrawString("to the party supplying the Software to the Customer.  In no event does Zygo warrant that the Software is error free or that the Customer will be able to operate the ", arial7, Brushes.Black, 50, nextpar);
            nextpar = nextpar + drop;
            ev.Graphics.DrawString("Software without problems or interruptions.", arial7, Brushes.Black, 50, nextpar);
            nextpar = nextpar + drop + drop;
            ev.Graphics.DrawString("This warranty does not apply if the Software (a) has been altered, except by Zygo, (b) has not been installed, operated, repaired, or maintained in accordance with ", arial7, Brushes.Black, 50, nextpar);
            nextpar = nextpar + drop;
            ev.Graphics.DrawString("instructions supplied by Zygo, (c) has been subjected to abnormal physical or electrical stress, misuse, negligence, or accident, or (d) is used in hazardous activities.", arial7, Brushes.Black, 50, nextpar);
            nextpar = nextpar + drop + drop;
            ev.Graphics.DrawString("DISCLAIMER.  EXCEPT AS SPECIFIED IN THIS WARRANTY, ALL EXPRESS OR IMPLIED CONDITIONS, REPRESENTATIONS, AND WARRANTIES INCLUDING, ", arial7, Brushes.Black, 50, nextpar);
            nextpar = nextpar + drop;
            ev.Graphics.DrawString("WITHOUT LIMITATION, ANY IMPLIED WARRANTY OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE, NONINFRINGEMENT OR ARISING FROM", arial7, Brushes.Black, 50, nextpar);
            nextpar = nextpar + drop;
            ev.Graphics.DrawString("A COURSE OF DEALING, USAGE, OR TRADE PRACTICE, ARE HEREBY EXCLUDED TO THE EXTENT ALLOWED BY APPLICABLE LAW.", arial7, Brushes.Black, 50, nextpar);
            nextpar = nextpar + drop + drop;
            ev.Graphics.DrawString("IN NO EVENT WILL ZYGO OR ITS SUPPLIERS BE LIABLE FOR ANY LOST REVENUE, PROFIT, OR DATA, OR FOR SPECIAL, INDIRECT, CONSEQUENTIAL,", arial7, Brushes.Black, 50, nextpar);
            nextpar = nextpar + drop;
            ev.Graphics.DrawString("INCIDENTAL, OR PUNITIVE DAMAGES HOWEVER CAUSED AND REGARDLESS OF THE THEORY OF LIABILITY ARISING OUT OF THE USE OF OR INABILITY", arial7, Brushes.Black, 50, nextpar);
            nextpar = nextpar + drop;
            ev.Graphics.DrawString("TO USE THE SOFTWARE EVEN IF ZYGO OR ITS SUPPLIERS HAVE BEEN ADVISED OF THE POSSIBILITY OF SUCH DAMAGES.  In no event shall Zygo's or its", arial7, Brushes.Black, 50, nextpar);
            nextpar = nextpar + drop;
            ev.Graphics.DrawString("supppliers' liability to Customer, whether in contract, tort (including negligence), or otherwise, exceed the price paid by Customer.  The foregoing limitations shall apply", arial7, Brushes.Black, 50, nextpar);
            nextpar = nextpar + drop;
            ev.Graphics.DrawString("even if the above-stated waranty fails of its essential purpose.  SOME STATES DO NOT ALLOW LIMITATION OR EXCLUSION OF LIABILITY FOR CONSEQUENTIAL", arial7, Brushes.Black, 50, nextpar);
            nextpar = nextpar + drop;
            ev.Graphics.DrawString("OR INCIDENTIAL DAMAGES.", arial7, Brushes.Black, 50, nextpar);
            nextpar = nextpar + drop + drop;
            ev.Graphics.DrawString("The above warranty DOES NOT apply to any beta software, any software made available for testing or demonstration purposes, any temporary software modules or any", arial7, Brushes.Black, 50, nextpar);
            nextpar = nextpar + drop;
            ev.Graphics.DrawString("software for which Zygo does not receive a license fee.  All such software products are provided AS IS without any warranty whatsoever.", arial7, Brushes.Black, 50, nextpar);
            nextpar = nextpar + drop + drop;
            ev.Graphics.DrawString("This License is effective until terminated.  Customer may terminate this License at any time by destroying all copies of Software including any documentation.  This ", arial7, Brushes.Black, 50, nextpar);
            nextpar = nextpar + drop;
            ev.Graphics.DrawString("License will terminate immediately without notice from Zygo if Customer fails to comply with any provision of this License.  Upon termination, Customer must destroy all", arial7, Brushes.Black, 50, nextpar);
            nextpar = nextpar + drop;
            ev.Graphics.DrawString("copies of Software.", arial7, Brushes.Black, 50, nextpar);
            nextpar = nextpar + drop + drop;
            ev.Graphics.DrawString("Software, including technical data, is subject to U.S. export control laws, including the U.S. Export Administration Act and its associated regulations, and may be subject", arial7, Brushes.Black, 50, nextpar);
            nextpar = nextpar + drop;
            ev.Graphics.DrawString("to export or import regulations in other countries.  Customer agrees to comply strictly with all such regulations and acknowledges that it has the responsibility to obtain", arial7, Brushes.Black, 50, nextpar);
            nextpar = nextpar + drop;
            ev.Graphics.DrawString("licenses to export, re-export, or import Software.", arial7, Brushes.Black, 50, nextpar);
            nextpar = nextpar + drop + drop;
            ev.Graphics.DrawString("This License shall be governed by and construed in accordance with the laws of the State of Connecticut, United States of America, as if performed wholly within the state", arial7, Brushes.Black, 50, nextpar);
            nextpar = nextpar + drop;
            ev.Graphics.DrawString("and without giving effect to the principles of conflict of law.  If any portion hereof is found to be void or unenforceable, the remainging provisions of this License shall", arial7, Brushes.Black, 50, nextpar);
            nextpar = nextpar + drop;
            ev.Graphics.DrawString("remain in full force and effect.  This License constitutes the entire License between the parties with respece to the use of the Software.", arial7, Brushes.Black, 50, nextpar);
            nextpar = nextpar + drop + drop;
            ev.Graphics.DrawString("Restricted Rights - Zygo's software is provided to non-DOD agencies with RESTRICTED RIGHTS and its supporting documentation is provided with LIMITED RIGHTS.", arial7, Brushes.Black, 50, nextpar);
            nextpar = nextpar + drop;
            ev.Graphics.DrawString(@"Use, duplication, or disclosure by the Government is subject to the restrictions as set forth in subparagraph ""C"" of the Commercial Computer Software - Restricted Rights", arial7, Brushes.Black, 50, nextpar);
            nextpar = nextpar + drop;
            ev.Graphics.DrawString("clause at FAR 52.227-19.  In the event the sale is to a DOD agency, the government's rights in software, supporting documentation, and technical data are governed ", arial7, Brushes.Black, 50, nextpar);
            nextpar = nextpar + drop;
            ev.Graphics.DrawString("by the restrictions in the Technical Data Commercial Items clause at DFARS 252.227-7025 and DFARS 227.7202.  Manufacturer is Zygo Corporation, Laurel Brook Rd.,", arial7, Brushes.Black, 50, nextpar);
            nextpar = nextpar + drop;
            ev.Graphics.DrawString("Middlefield, CT 06455", arial7, Brushes.Black, 50, nextpar);
            nextpar = nextpar + drop + drop;
            ev.Graphics.DrawString("201506", arial7, Brushes.Black, 50, nextpar);
            

            if (i > lineNo)
            {
                ev.HasMorePages = true;
                pagesPrinted++;
            }
            else
            {
                ev.HasMorePages = false;
                linedrop = 160;
                count = 0;
                pagesPrinted = 0;
                lineNo = 0;
            }

        }

    }
}
