using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Xml;
using MIM.classuni;
using MIM.Properties;
using System.Data.SqlClient;
using System.Data;
using System.Reflection;
using System.Net;
using System.Windows.Navigation;

namespace MIM
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        BackgroundWorker worker = new BackgroundWorker();

        public MainWindow()
        {
            InitializeComponent();
            SetProperties();
            Info();

            
            worker.WorkerReportsProgress = true;
            worker.DoWork += worker_DoWork;
            worker.ProgressChanged += worker_ProgressChanged;


            if (Settings.Default.optionsT1_Feature99_check == true)
                {
                 Start_sync_Click();
                }



        }




        #region ==============================================WindowsLeiste================================================
        private void ApplicationMinimized_Click(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        private void ApplicationMaximizedAndNormal_Click(object sender, RoutedEventArgs e)
        {
            if (WindowState == WindowState.Normal)
            {
                WindowState = WindowState.Maximized;
            }

            else if (WindowState == WindowState.Maximized)
            {
                WindowState = WindowState.Normal;
            }
        }

        private void ApplicationClose_Click(object sender, RoutedEventArgs e)
        {
            Settings.Default.Save();
            App.Current.Shutdown();
        }


        public void SetProperties()
        {
            try
            {
                // Icon für Window festlegen
                // Uri iconUri = new Uri("pack://application:,,,/Images/favicon.ico", UriKind.RelativeOrAbsolute);
                // this.Icon = BitmapFrame.Create(iconUri);
            }
            catch (Exception u)
            {
                MessageBox.Show("" + u);
            }


        }


        #endregion ==============================================WindowsLeiste================================================



        #region ==============================================Sidebar================================================

        private void WKZ_Click(object sender, RoutedEventArgs e)
        {

            try
            {


                if (g_wkz.Visibility == Visibility.Visible)

                {
                    g_Vc.Visibility = Visibility.Hidden;
                    g_wkz.Visibility = Visibility.Hidden;
                    g_NCup.Visibility = Visibility.Hidden;
                    g_about.Visibility = Visibility.Hidden;
                    g_set.Visibility = Visibility.Hidden;
                    g_pm.Visibility = Visibility.Hidden;
                }

                else if (g_wkz.Visibility == Visibility.Hidden)

                {
                    g_wkz.Visibility = Visibility.Visible;
                    g_Vc.Visibility = Visibility.Hidden;
                    g_NCup.Visibility = Visibility.Hidden;
                    g_about.Visibility = Visibility.Hidden;
                    g_set.Visibility = Visibility.Hidden;
                    g_pm.Visibility = Visibility.Hidden;
                }

            }
            catch (Exception u)
            {
                _ = MessageBox.Show("" + u);
            }



        }

        private void VCParser_Click(object sender, RoutedEventArgs e)
        {


            try
            {
                if (g_Vc.Visibility == Visibility.Visible)

                {
                    g_Vc.Visibility = Visibility.Hidden;
                    g_wkz.Visibility = Visibility.Hidden;
                    g_NCup.Visibility = Visibility.Hidden;
                    g_about.Visibility = Visibility.Hidden;
                    g_set.Visibility = Visibility.Hidden;
                    g_pm.Visibility = Visibility.Hidden;
                }

                else if (g_Vc.Visibility == Visibility.Hidden)

                {
                    g_Vc.Visibility = Visibility.Visible;
                    g_wkz.Visibility = Visibility.Hidden;
                    g_NCup.Visibility = Visibility.Hidden;
                    g_about.Visibility = Visibility.Hidden;
                    g_set.Visibility = Visibility.Hidden;
                    g_pm.Visibility = Visibility.Hidden;
                }

            }
            catch (Exception u)
            {
                _ = MessageBox.Show("" + u);
            }




        }

        private void NCr_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (g_NCup.Visibility == Visibility.Visible)

                {
                    g_Vc.Visibility = Visibility.Hidden;
                    g_wkz.Visibility = Visibility.Hidden;
                    g_NCup.Visibility = Visibility.Hidden;
                    g_about.Visibility = Visibility.Hidden;
                    g_set.Visibility = Visibility.Hidden;
                    g_pm.Visibility = Visibility.Hidden;
                }

                else if (g_NCup.Visibility == Visibility.Hidden)

                {
                    g_NCup.Visibility = Visibility.Visible;
                    g_Vc.Visibility = Visibility.Hidden;
                    g_wkz.Visibility = Visibility.Hidden;
                    g_about.Visibility = Visibility.Hidden;
                    g_set.Visibility = Visibility.Hidden;
                    g_pm.Visibility = Visibility.Hidden;

                }

            }
            catch (Exception u)
            {
                _ = MessageBox.Show("" + u);
            }
        }

        private void PM_Click(object sender, RoutedEventArgs e)
        {
            try
            {

                if (g_pm.Visibility == Visibility.Visible)

                {
                    g_Vc.Visibility = Visibility.Hidden;
                    g_wkz.Visibility = Visibility.Hidden;
                    g_NCup.Visibility = Visibility.Hidden;
                    g_about.Visibility = Visibility.Hidden;
                    g_set.Visibility = Visibility.Hidden;
                    g_pm.Visibility = Visibility.Hidden;
                }

                else if (g_pm.Visibility == Visibility.Hidden)

                {
                    g_pm.Visibility = Visibility.Hidden;    //g_pm.Visibility = Visibility.Visible;
                    g_set.Visibility = Visibility.Hidden;
                    g_about.Visibility = Visibility.Hidden;
                    g_wkz.Visibility = Visibility.Hidden;
                    g_Vc.Visibility = Visibility.Hidden;
                    g_NCup.Visibility = Visibility.Hidden;
                }

            }

            catch (Exception u)
            {
                _ = MessageBox.Show("" + u);
            }
        }

        private void INFO_Click(object sender, RoutedEventArgs e)
        {
            try
            {


                if (g_about.Visibility == Visibility.Visible)

                {
                    g_Vc.Visibility = Visibility.Hidden;
                    g_wkz.Visibility = Visibility.Hidden;
                    g_NCup.Visibility = Visibility.Hidden;
                    g_about.Visibility = Visibility.Hidden;
                    g_set.Visibility = Visibility.Hidden;
                    g_pm.Visibility = Visibility.Hidden;
                }

                else if (g_about.Visibility == Visibility.Hidden)

                {
                    g_about.Visibility = Visibility.Visible;
                    g_wkz.Visibility = Visibility.Hidden;
                    g_Vc.Visibility = Visibility.Hidden;
                    g_NCup.Visibility = Visibility.Hidden;
                    g_set.Visibility = Visibility.Hidden;
                    g_pm.Visibility = Visibility.Hidden;
                }

            }
            catch (Exception u)
            {
                _ = MessageBox.Show("" + u);
            }

        }

        private void SETTINGS_Click(object sender, RoutedEventArgs e)
        {

            try
            {

                if (g_set.Visibility == Visibility.Visible)

                {
                    g_Vc.Visibility = Visibility.Hidden;
                    g_wkz.Visibility = Visibility.Hidden;
                    g_NCup.Visibility = Visibility.Hidden;
                    g_about.Visibility = Visibility.Hidden;
                    g_set.Visibility = Visibility.Hidden;
                    g_pm.Visibility = Visibility.Hidden;
                }

                else if (g_set.Visibility == Visibility.Hidden)

                {
                    g_set.Visibility = Visibility.Visible;
                    g_about.Visibility = Visibility.Hidden;
                    g_wkz.Visibility = Visibility.Hidden;
                    g_Vc.Visibility = Visibility.Hidden;
                    g_NCup.Visibility = Visibility.Hidden;
                    g_pm.Visibility = Visibility.Hidden;
                }

            }

            catch (Exception u)
            {
                _ = MessageBox.Show("" + u);
            }
        }




        private void CLOSEd_Click(object sender, RoutedEventArgs e)
        {
            Settings.Default.Save();
            Environment.Exit(0);                                             // Fenster schließen über MEnue
        }

        #endregion ==============================================Sidebar================================================

       

        #region ==============================================XML-sync================================================

        // Filewatcher
        FileSystemWatcher FSW;

        private void Start_sync_Click()
        {


            try
            {
                // gui log leeren
                Settings.Default.syncxml_Info = "";

                // Buttons available
                btn_Start_sync.IsEnabled = false;
                btn_stop_sync.IsEnabled = true;
                Grid_Setting.IsEnabled = false;

                // PFad zum überwachen aus Settings lesen
                string path = Settings.Default.optionsT1_source;

                // Create a new FileSystemWatcher and set its properties.
                FSW = new FileSystemWatcher
                {
                    Path = @path,

                    // Only watch text files.      
                    Filter = "*.xml"
                };

                //FSW.Changed += new FileSystemEventHandler(FSW_Changed);
                FSW.Created += new FileSystemEventHandler(FSW_Created);
                //FSW.Deleted += new FileSystemEventHandler(FSW_Deleted);
                //FSW.Renamed += new RenamedEventHandler(FSW_Renamed);

                // Begin watching.      
                FSW.EnableRaisingEvents = true;

                // write Status to xaml
                status.Content = "FILEWATCHER RUN";
                status.Foreground = new SolidColorBrush(Color.FromArgb(0xFF, 0xA3, 0xE2, 0x8B));

                LogINIT();


            }

            catch (Exception u)
            {
                MessageBox.Show("" + u);
            }

        }

        public void Btn_Start_sync_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // gui log leeren
                Settings.Default.syncxml_Info = "";

                // Buttons available
                btn_Start_sync.IsEnabled = false;
                btn_stop_sync.IsEnabled = true;
                Grid_Setting.IsEnabled = false;

                // PFad zum überwachen aus Settings lesen
                string path = Settings.Default.optionsT1_source;

                // Create a new FileSystemWatcher and set its properties.
                FSW = new FileSystemWatcher
                {
                    Path = @path,

                    // Only watch text files.      
                    Filter = "*.xml"
                };

                //FSW.Changed += new FileSystemEventHandler(FSW_Changed);
                FSW.Created += new FileSystemEventHandler(FSW_Created);
                //FSW.Deleted += new FileSystemEventHandler(FSW_Deleted);
                //FSW.Renamed += new RenamedEventHandler(FSW_Renamed);

                // Begin watching.      
                FSW.EnableRaisingEvents = true;

                // write Status to xaml
                status.Content = "FILEWATCHER RUN";
                status.Foreground = new SolidColorBrush(Color.FromArgb(0xFF, 0xA3, 0xE2, 0x8B));

                LogINIT();


            }

            catch (Exception u)
            {
                MessageBox.Show("" + u);
            }
        }

        // Define the event handler.
        private void FSW_Created(object source, FileSystemEventArgs e)
        {
            try
            {
                // =================================================================================HEAD==============================================================================================
                string ROOTXML = Properties.Settings.Default.optionsT1_source;       // Wurzelverzeichis der zu ladenden XML
                string TARGETXML = Properties.Settings.Default.optionsT1_destination;   // Zielverzeichnis der zu schreibenden XML

                string[] xmlListEXIST = Directory.GetFiles(ROOTXML, "*.xml");
                int anzahlxml = xmlListEXIST.GetLength(0);


                while (anzahlxml != 0)

                {


                    Thread.Sleep(800);  // Warte...

                    Task.Run(() =>
                    {
                        Dispatcher.Invoke(() =>
                        {
                            tb_AusgabeDBINFO.Foreground = new SolidColorBrush(Color.FromArgb(0xFF, 0xB8, 0xB8, 0xB8));
                        });
                    });


                    // array der ganzen .xml erstellen
                    string[] xmlList = Directory.GetFiles(ROOTXML, "*.xml");

                    // Pfadangabe löschen, es bleibt nur die Datei
                    string filename = null;
                    filename = System.IO.Path.GetFileName(xmlList[0]);

                    // Extension löschen (.xml)
                    char[] MyChar = { 'x', 'm', 'l', '.' };
                    string filnamewithoutExtension = filename.TrimEnd(MyChar);

                    // Erstelle neue NC Nummer für XML eintrag
                    string path1 = @ROOTXML + filename;
                    string newNCNUMBER = filnamewithoutExtension + "000";

                    // stringbuilder für Info
                    StringBuilder sb = new();
                    _ = sb.Append("===================  neues Wkz gefunden " + filename + "  ====================" + "\n");


                    // ================================================================================FEATURE 1 Status zu Name)
                    if (Settings.Default.optionsT1_Feature1_check == true)
                    {
                        XmlDocument xmlDoc = new();
                        xmlDoc.Load(path1);

                        XmlNode noderead1 = xmlDoc.SelectSingleNode("/omtdx/ncTools/ncTools/ncTools/ncTool/customData/param[@name='Werkzeugstatus']");

                        if (noderead1 != null)
                        {

                            var Status = noderead1.Attributes["value"].Value;

                            // Lese bestehenden Werkzeugnamen
                            XmlNode noderead2 = xmlDoc.SelectSingleNode("omtdx/ncTools/ncTools/ncTools/ncTool");

                            if (noderead2 != null)
                            {
                                var bNcname = noderead2.Attributes["name"].Value;

                                // Schreibe neuen Werkzeugnamen
                                XmlNode nodewrite = xmlDoc.SelectSingleNode("omtdx/ncTools/ncTools/ncTools/ncTool");
                                nodewrite.Attributes[2].Value = Status + " // " + bNcname;

                                _ = sb.Append("\n" + " --> ADD STATUS TO NAME: NameWkz geändert auf -> " + Status + " // " + bNcname);

                            }
                            else { }
                        }
                        else { }


                        xmlDoc.Save(path1);
                    }

                    // ================================================================================FEATURE 2 (Status 000 zu NCNr) 
                    if (Settings.Default.optionsT1_Feature2_check == true)

                    {
                        XmlDocument xmlDoc = new();
                        xmlDoc.Load(path1);

                        XmlNode node = xmlDoc.SelectSingleNode("omtdx/ncTools/ncTools/ncTools/ncTool");

                        if (node is not null)
                        {
                            node.Attributes[1].Value = newNCNUMBER;
                            _ = sb.Append("\n" + " --> UNGEPRÜFTES WKZ:    NC-Nummer auf:   '" + newNCNUMBER + "'   geändert");
                        }
                        else
                        {
                            _ = sb.Append("\n" + " --> UNGEPRÜFTES WKZ:    Knoten nicht vorhanden, 000 konnte nicht hinzugefügt werden");
                        }


                        xmlDoc.Save(path1);
                    }

                    // ================================================================================FEATURE 3 (Referenzpunkte)
                    if (Settings.Default.optionsT1_Feature3_check == true)
                    {
                        XmlDocument xmlDoc = new();
                        xmlDoc.Load(path1);


                        // Lesen von Werkzeugreferenzpunkt
                        XmlNode noderead1 = xmlDoc.SelectSingleNode("/omtdx/ncTools/ncTools/ncTools/ncTool/referencePoints/referencePoint");

                        if (noderead1 != null)
                        {
                            var refpoint1 = noderead1.Attributes["name"].Value;

                            // Lesen von Werkzeugklasse
                            XmlNode noderead2 = xmlDoc.SelectSingleNode("/omtdx/tools/tools/tools/tool");
                            if (noderead2 != null)
                            {
                                var toolclass = noderead2.Attributes["type"].Value;

                                if (refpoint1 == "S2" && toolclass == "drilTool")
                                {
                                    // Schreibe neuen Werkzeugfefernznamen
                                    XmlNode nodewrite = xmlDoc.SelectSingleNode("/omtdx/ncTools/ncTools/ncTools/ncTool/referencePoints/referencePoint");
                                    nodewrite.Attributes[1].Value = "1";

                                    _ = sb.Append("\n" + " --> WKZ-REF:            Klasse 'toolDrill' u. Refp. '" + refpoint1 + "' erkannt --> Name geaendert auf '1' ");

                                }
                                else
                                {
                                    _ = sb.Append("\n" + " --> WKZ-REF:            W-Ref nicht gefunden und/oder Klasse ist kein Bohrer  ");

                                }
                            }
                            else
                            {
                                _ = sb.Append("\n" + " --> WKZ-REF:            Referenzpunkte gefunden, Eintrag Werkzeugklasse nicht gefunden");
                            }
                        }
                        else
                        {
                            _ = sb.Append("\n" + " --> WKZ-REF:            Keine Referenzpunktinformationen enthalten ");
                        }

                        xmlDoc.Save(path1);
                    }

                    // ================================================================================FEATURE 4 (alternative Ordnernamen) 
                    if (Settings.Default.optionsT1_Feature4_check == true)
                    {
                        XmlDocument xmlDoc = new();
                        xmlDoc.Load(path1);


                        XmlNode noderead1 = xmlDoc.SelectSingleNode("/omtdx/ncTools/ncTools");

                        if (noderead1 != null)
                        {
                            var folder = noderead1.Attributes["folder"].Value;


                            switch (folder)
                            {
                                // ------------------Fräswerkzeuge
                                case "Planfräser / Messerköpfe":
                                    noderead1.Attributes[0].Value = "7000 - Planfräser / Messerköpfe";
                                    _ = sb.Append("\n" + " --> Alter. ORDNERNAME:  Klasse " + noderead1.Attributes[0].Value + " gefunden -> Ordner aktualisiert");
                                    break;

                                case "Schaftfräser":
                                    noderead1.Attributes[0].Value = "7003 - Schaftfräser";
                                    _ = sb.Append("\n" + " --> Alter. ORDNERNAME:  Klasse " + noderead1.Attributes[0].Value + " gefunden -> Ordner aktualisiert");
                                    break;

                                case "Kugelfräser / Ballfräser":
                                    noderead1.Attributes[0].Value = "7004 - Kugelfräser / Ballfräser";
                                    _ = sb.Append("\n" + " --> Alter. ORDNERNAME:  Klasse " + noderead1.Attributes[0].Value + " gefunden -> Ordner aktualisiert");
                                    break;

                                case "Formfräser / Sonderfräswerkzeuge":
                                    noderead1.Attributes[0].Value = "7006 - Formfräser / Sonderfräswerkzeuge";
                                    _ = sb.Append("\n" + " --> Alter. ORDNERNAME:  Klasse " + noderead1.Attributes[0].Value + " gefunden -> Ordner aktualisiert");
                                    break;

                                case "Gewindefräser":
                                    noderead1.Attributes[0].Value = "7008 - Gewindefräser";
                                    _ = sb.Append("\n" + " --> Alter. ORDNERNAME:  Klasse " + noderead1.Attributes[0].Value + " gefunden -> Ordner aktualisiert");
                                    break;

                                case "Scheibenfräser und Sägeblätter":
                                    noderead1.Attributes[0].Value = "7009 - Scheibenfräser und Sägeblätter";
                                    _ = sb.Append("\n" + " --> Alter. ORDNERNAME:  Klasse " + noderead1.Attributes[0].Value + " gefunden -> Ordner aktualisiert");
                                    break;

                                case "Tonnen- / Linsenfräser":
                                    noderead1.Attributes[0].Value = "7011 - Tonnen- / Linsenfräser";
                                    _ = sb.Append("\n" + " --> Alter. ORDNERNAME:  Klasse " + noderead1.Attributes[0].Value + " gefunden -> Ordner aktualisiert");
                                    break;

                                case "Radienfräser":
                                    noderead1.Attributes[0].Value = "7012 - Radienfräser";
                                    _ = sb.Append("\n" + " --> Alter. ORDNERNAME:  Klasse " + noderead1.Attributes[0].Value + " gefunden -> Ordner aktualisiert");
                                    break;

                                case "T-Nutenfräser":
                                    noderead1.Attributes[0].Value = "7014 - T-Nutenfräser";
                                    _ = sb.Append("\n" + " --> Alter. ORDNERNAME:  Klasse " + noderead1.Attributes[0].Value + " gefunden -> Ordner aktualisiert");
                                    break;

                                //------------------------------Bohrwerkzeuge--------------------

                                case "NC-Anbohrer":
                                    noderead1.Attributes[0].Value = "7101 - NC-Anbohrer";
                                    break;

                                case "Bohrer":
                                    noderead1.Attributes[0].Value = "7101 - Bohrer";
                                    _ = sb.Append("\n" + " --> Alter. ORDNERNAME:  Klasse " + noderead1.Attributes[0].Value + " gefunden -> Ordner aktualisiert");
                                    break;

                                case "Reibahlen":
                                    noderead1.Attributes[0].Value = "7102 - Reibahlen";
                                    _ = sb.Append("\n" + " --> Alter. ORDNERNAME:  Klasse " + noderead1.Attributes[0].Value + " gefunden -> Ordner aktualisiert");
                                    break;

                                case "Spindler / Ausdreher":
                                    noderead1.Attributes[0].Value = "7103 - Spindler / Ausdreher";
                                    _ = sb.Append("\n" + " --> Alter. ORDNERNAME:  Klasse " + noderead1.Attributes[0].Value + " gefunden -> Ordner aktualisiert");
                                    break;

                                case "Zentrierbohrer":
                                    noderead1.Attributes[0].Value = "7104 - Zentrierbohrer";
                                    _ = sb.Append("\n" + " --> Alter. ORDNERNAME:  Klasse " + noderead1.Attributes[0].Value + " gefunden -> Ordner aktualisiert");
                                    break;

                                case "Formbohrer & Reibahlen":
                                    noderead1.Attributes[0].Value = "7105 - Formbohrer & Reibahlen";
                                    _ = sb.Append("\n" + " --> Alter. ORDNERNAME:  Klasse " + noderead1.Attributes[0].Value + " gefunden -> Ordner aktualisiert");
                                    break;

                                //------------------------------Gewindebohrer-/former--------------------

                                case "Metrische-Gewinde":
                                    noderead1.Attributes[0].Value = "7200 - Metrische-Gewinde";
                                    _ = sb.Append("\n" + " --> Alter. ORDNERNAME:  Klasse " + noderead1.Attributes[0].Value + " gefunden -> Ordner aktualisiert");
                                    break;

                                case "Zoll-Gewinde":
                                    noderead1.Attributes[0].Value = "7201 - Zoll-Gewinde";
                                    _ = sb.Append("\n" + " --> Alter. ORDNERNAME:  Klasse " + noderead1.Attributes[0].Value + " gefunden -> Ordner aktualisiert");
                                    break;

                                case "Sonder-Gewinde":
                                    noderead1.Attributes[0].Value = "7202 - Sonder-Gewinde";
                                    _ = sb.Append("\n" + " --> Alter. ORDNERNAME:  Klasse " + noderead1.Attributes[0].Value + " gefunden -> Ordner aktualisiert");
                                    break;

                                //------------------------------Senk und Faswerkzeuge --------------------

                                case "Senk-Werkzeuge":
                                    noderead1.Attributes[0].Value = "7300 - Senk-Werkzeuge";
                                    _ = sb.Append("\n" + " --> Alter. ORDNERNAME:  Klasse " + noderead1.Attributes[0].Value + " gefunden -> Ordner aktualisiert");
                                    break;

                                case "Entgratfräser (nur Winkel schneidend)":
                                    noderead1.Attributes[0].Value = "7303 - Entgratfräser (nur Winkel schneidend)";
                                    _ = sb.Append("\n" + " --> Alter. ORDNERNAME:  Klasse " + noderead1.Attributes[0].Value + " gefunden -> Ordner aktualisiert");
                                    break;

                                case "Fasenfräser (mit Umfangsscheide)":
                                    noderead1.Attributes[0].Value = "7304 - Fasenfräser (mit Umfangsschneide)";
                                    _ = sb.Append("\n" + " --> Alter. ORDNERNAME:  Klasse " + noderead1.Attributes[0].Value + " gefunden -> Ordner aktualisiert");
                                    break;

                                case "Fasen- und Schriftstichel":
                                    noderead1.Attributes[0].Value = "7305 - Fasen- und Schriftstichel";
                                    _ = sb.Append("\n" + " --> Alter. ORDNERNAME:  Klasse " + noderead1.Attributes[0].Value + " gefunden -> Ordner aktualisiert");
                                    break;

                                //------------------------------Messtaster --------------------

                                case "Messtaster & Messdorne":
                                    noderead1.Attributes[0].Value = "7500 - Messtaster & Messdorne";
                                    _ = sb.Append("\n" + " --> Alter. ORDNERNAME:  Klasse " + noderead1.Attributes[0].Value + " gefunden -> Ordner aktualisiert");
                                    break;

                                //------------------------------Reinigungswkz Propeller etc --------------------

                                case "Bürsten, Propeller, usw...":
                                    noderead1.Attributes[0].Value = "7600 - Bürsten, Propeller, usw...";
                                    _ = sb.Append("\n" + " --> Alter. ORDNERNAME:  Klasse " + noderead1.Attributes[0].Value + " gefunden -> Ordner aktualisiert");
                                    break;

                                //------------------------------Wenns mal wieder schiefläuft --------------------
                                default:
                                    _ = sb.Append("\n" + " --> Alter. ORDNERNAME:  Klasse für Ordner nicht gefunden ");
                                    break;
                            }
                        }
                        xmlDoc.Save(path1);
                    }

                    // ================================================================================FEATURE 5 (parametrischen Schaft setzen)  
                    if (Settings.Default.optionsT1_Feature5_check == true)
                    {
                        XmlDocument xmlDoc = new();
                        xmlDoc.Load(path1);             // xml laden

                        XmlNode wkzclass = xmlDoc.SelectSingleNode("/omtdx/tools/tools/tools/tool");
                        var toolclass = wkzclass.Attributes["type"].Value;

                        if (toolclass == "endMill" | toolclass == "radiusMill" | toolclass == "ballMill")
                        {
                            XmlNode nominalD = xmlDoc.SelectSingleNode("/omtdx/tools/tools/tools/tool/param[@name='toolDiameter']");
                            XmlNode shaftD = xmlDoc.SelectSingleNode("/omtdx/tools/tools/tools/tool/param[@name='toolShaftDiameter']");
                            XmlNode shaftm = xmlDoc.SelectSingleNode("/omtdx/tools/tools/tools/tool/param[@name='toolShaftType']");

                            if (nominalD != null && shaftD != null && shaftm != null)
                            {
                                var nominalDiameter = nominalD.Attributes["value"].Value;
                                var shaftDiameter = shaftD.Attributes["value"].Value;
                                var shaftmode = shaftm.Attributes["value"].Value;

                                if (nominalDiameter == shaftDiameter && shaftmode == "free")
                                {
                                    shaftm.Attributes[1].Value = "parametric";
                                    _ = sb.Append("\n" + " --> SCHAFTPARAMETRIK:   NominalØ = SchaftØ --> Schaft wird auf PARAMETRIK gesetzt ");
                                }
                                else
                                {
                                    _ = sb.Append("\n" + " --> SCHAFTPARAMETRIK:   NominalØ != SchaftØ --> Schaft bleibt FREE ");
                                }
                            }
                            else
                            {
                                _ = sb.Append("\n" + " --> SCHAFTPARAMETRIK:   erfolderliche Werte nicht in xml enthalten ");
                            }
                        }


                        else
                        {
                            _ = sb.Append("\n" + " --> SCHAFTPARAMETRIK:   Keine unterstützte Klasse");
                        }

                        xmlDoc.Save(path1);
                    }

                    // ================================================================================FEATURE 6 (geprüft Status hinzu)
                    if (Settings.Default.optionsT1_Feature6_check == true)
                    {
                        XmlDocument xmlDoc = new();
                        xmlDoc.Load(path1);             // xml laden

                        XmlNode noderead1 = xmlDoc.SelectSingleNode("/omtdx/ncTools/ncTools/ncTools/ncTool/customData");

                        if (noderead1 != null)
                        {
                            //Create a new node.
                            XmlElement elem = xmlDoc.CreateElement("param");
                            noderead1.InsertBefore(elem, noderead1.LastChild);

                            // Create new Attribute
                            XmlNode noderead2 = xmlDoc.SelectSingleNode("/omtdx/ncTools/ncTools/ncTools/ncTool/customData/param");

                            // Attribute 1
                            XmlAttribute attr1 = xmlDoc.CreateAttribute("name");
                            attr1.Value = "geprueft";
                            noderead2.Attributes.SetNamedItem(attr1);

                            // Attribute 2
                            XmlAttribute attr2 = xmlDoc.CreateAttribute("value");
                            attr2.Value = "nein";
                            noderead2.Attributes.SetNamedItem(attr2);

                            _ = sb.Append("\n" + " --> STATUS GEPRUEFT:    Erfolgreich hinzugefügt");

                        }
                        else
                        {
                            _ = sb.Append("\n" + " --> STATUS GEPRUEFT:    Knoten customData nicht gefunden");
                        }


                        xmlDoc.Save(path1);
                    }

                    // ================================================================================FEATURE 7 (überprüfe auf Fehler)
                    if (Settings.Default.optionsT1_Feature7_check == true)
                    {
                        XmlDocument xmlDoc = new();
                        xmlDoc.Load(path1);             // xml laden

                        XmlNode wkzclass = xmlDoc.SelectSingleNode("/omtdx/tools/tools/tools/tool");
                        XmlNode shaftflag = xmlDoc.SelectSingleNode("/omtdx/tools/tools/tools/tool/param[@name='toolShaftEnabled']");

                        XmlNode wkzgroup = xmlDoc.SelectSingleNode("/omtdx/ncTools/ncTools");
                        var mk = wkzgroup.Attributes["folder"].Value; // Werkzeuggruppennamen lesen

                        var toolclass = wkzclass.Attributes["type"].Value;
                        if (mk == "Planfräser / Messerköpfe")
                        {
                            _ = sb.Append("\n" + " --> BUG-CHECK:          Messerkopf Schaftprüfung deaktiviert");
                        }
                        else
                        {
                            // Schaft prüfung
                            switch (toolclass)
                            {
                                case "endMill":
                                    if (shaftflag != null)
                                    {
                                        var valueshaftflag = shaftflag.Attributes["value"].Value;

                                        if (valueshaftflag == "1")
                                        {
                                            _ = sb.Append("\n" + " --> BUG-CHECK:          Schaft-Check --> all is good");
                                        }
                                        else
                                        {
                                            _ = sb.Append("\n" + " --> BUG-CHECK:          !!! ATTENTION !!! Schaft nicht aktiviert");

                                            // ====================  START FÜGE HINWEIS IN XML =====================
                                            // Lese bestehenden Werkzeugnamen
                                            XmlNode noderead2 = xmlDoc.SelectSingleNode("omtdx/ncTools/ncTools/ncTools/ncTool");
                                            XmlNode noderead3 = xmlDoc.SelectSingleNode("omtdx/ncTools/ncTools/ncTools/ncTools/ncTool");
                                            if (noderead2 != null)
                                            {
                                                var bNcname = noderead2.Attributes["name"].Value;
                                                // Schreibe neuen Werkzeugnamen
                                                XmlNode nodewrite = xmlDoc.SelectSingleNode("omtdx/ncTools/ncTools/ncTools/ncTool");
                                                nodewrite.Attributes[2].Value = "!! ATTENTION !!! Schaft FEHLT" + " // " + bNcname;
                                            }
                                            else if (noderead3 != null)  // (notwedig falls in Feature Statusordner ein Ordner hinzugefügt wurde)
                                            {
                                                var bNcname = noderead3.Attributes["name"].Value;
                                                // Schreibe neuen Werkzeugnamen
                                                XmlNode nodewrite = xmlDoc.SelectSingleNode("omtdx/ncTools/ncTools/ncTools/ncTools/ncTool");
                                                nodewrite.Attributes[2].Value = "!! ATTENTION !!! Schaft FEHLT" + " // " + bNcname;
                                            }
                                            else
                                            {
                                                _ = sb.Append("\n" + " --> BUG-CHECK:          !!! ERROR !!! Schreiben in XML fehlgeschlagen - Knoten nicht vorhanden");
                                            }
                                            // ==================== ENDE FÜGE HINWEIS IN XML =====================
                                        }
                                    }
                                    else
                                    {
                                        _ = sb.Append("\n" + " --> BUG-CHECK:          !!! ATTENTION !!! Schaftknoten in XML fehlt");

                                        // ====================  START FÜGE HINWEIS IN XML =====================
                                        // Lese bestehenden Werkzeugnamen
                                        XmlNode noderead2 = xmlDoc.SelectSingleNode("omtdx/ncTools/ncTools/ncTools/ncTool");
                                        XmlNode noderead3 = xmlDoc.SelectSingleNode("omtdx/ncTools/ncTools/ncTools/ncTools/ncTool");
                                        if (noderead2 != null)
                                        {
                                            var bNcname = noderead2.Attributes["name"].Value;
                                            // Schreibe neuen Werkzeugnamen
                                            XmlNode nodewrite = xmlDoc.SelectSingleNode("omtdx/ncTools/ncTools/ncTools/ncTool");
                                            nodewrite.Attributes[2].Value = "!! ATTENTION !!! Schaft FEHLT" + " // " + bNcname;
                                        }
                                        else if (noderead3 != null)  // (notwedig falls in Feature Statusordner ein Ordner hinzugefügt wurde)
                                        {
                                            var bNcname = noderead3.Attributes["name"].Value;
                                            // Schreibe neuen Werkzeugnamen
                                            XmlNode nodewrite = xmlDoc.SelectSingleNode("omtdx/ncTools/ncTools/ncTools/ncTools/ncTool");
                                            nodewrite.Attributes[2].Value = "!! ATTENTION !!! Schaft FEHLT" + " // " + bNcname;
                                        }
                                        else
                                        {
                                            _ = sb.Append("\n" + " --> BUG-CHECK:          !!! ERROR !!! Schreiben in XML fehlgeschlagen - Knoten nicht vorhanden");
                                        }
                                        // ==================== ENDE FÜGE HINWEIS IN XML =====================
                                    }
                                    break;


                                case "radiusMill":
                                    if (shaftflag != null)
                                    {
                                        var valueshaftflag = shaftflag.Attributes["value"].Value;

                                        if (valueshaftflag == "1")
                                        {
                                            _ = sb.Append("\n" + " --> BUG-CHECK:          Schaft-Check --> all is good");
                                        }
                                        else
                                        {
                                            _ = sb.Append("\n" + " --> BUG-CHECK:          !!! ATTENTION !!! Schaft nicht aktiviert");

                                            // ====================  START FÜGE HINWEIS IN XML =====================
                                            // Lese bestehenden Werkzeugnamen
                                            XmlNode noderead2 = xmlDoc.SelectSingleNode("omtdx/ncTools/ncTools/ncTools/ncTool");
                                            XmlNode noderead3 = xmlDoc.SelectSingleNode("omtdx/ncTools/ncTools/ncTools/ncTools/ncTool");
                                            if (noderead2 != null)
                                            {
                                                var bNcname = noderead2.Attributes["name"].Value;
                                                // Schreibe neuen Werkzeugnamen
                                                XmlNode nodewrite = xmlDoc.SelectSingleNode("omtdx/ncTools/ncTools/ncTools/ncTool");
                                                nodewrite.Attributes[2].Value = "!! ATTENTION !!! Schaft FEHLT" + " // " + bNcname;
                                            }
                                            else if (noderead3 != null)  // (notwedig falls in Feature Statusordner ein Ordner hinzugefügt wurde)
                                            {
                                                var bNcname = noderead3.Attributes["name"].Value;
                                                // Schreibe neuen Werkzeugnamen
                                                XmlNode nodewrite = xmlDoc.SelectSingleNode("omtdx/ncTools/ncTools/ncTools/ncTools/ncTool");
                                                nodewrite.Attributes[2].Value = "!! ATTENTION !!! Schaft FEHLT" + " // " + bNcname;
                                            }
                                            else
                                            {
                                                _ = sb.Append("\n" + " --> BUG-CHECK:          !!! ERROR !!! Schreiben in XML fehlgeschlagen - Knoten nicht vorhanden");
                                            }
                                            // ==================== ENDE FÜGE HINWEIS IN XML =====================
                                        }
                                    }
                                    else
                                    {
                                        _ = sb.Append("\n" + " --> BUG-CHECK:          !!! ATTENTION !!! Schaftknoten in XML fehlt");

                                        // ====================  START FÜGE HINWEIS IN XML =====================
                                        // Lese bestehenden Werkzeugnamen
                                        XmlNode noderead2 = xmlDoc.SelectSingleNode("omtdx/ncTools/ncTools/ncTools/ncTool");
                                        XmlNode noderead3 = xmlDoc.SelectSingleNode("omtdx/ncTools/ncTools/ncTools/ncTools/ncTool");
                                        if (noderead2 != null)
                                        {
                                            var bNcname = noderead2.Attributes["name"].Value;
                                            // Schreibe neuen Werkzeugnamen
                                            XmlNode nodewrite = xmlDoc.SelectSingleNode("omtdx/ncTools/ncTools/ncTools/ncTool");
                                            nodewrite.Attributes[2].Value = "!! ATTENTION !!! Schaft FEHLT" + " // " + bNcname;
                                        }
                                        else if (noderead3 != null)  // (notwedig falls in Feature Statusordner ein Ordner hinzugefügt wurde)
                                        {
                                            var bNcname = noderead3.Attributes["name"].Value;
                                            // Schreibe neuen Werkzeugnamen
                                            XmlNode nodewrite = xmlDoc.SelectSingleNode("omtdx/ncTools/ncTools/ncTools/ncTools/ncTool");
                                            nodewrite.Attributes[2].Value = "!! ATTENTION !!! Schaft FEHLT" + " // " + bNcname;
                                        }
                                        else
                                        {
                                            _ = sb.Append("\n" + " --> BUG-CHECK:          !!! ERROR !!! Schreiben in XML fehlgeschlagen - Knoten nicht vorhanden");
                                        }
                                        // ==================== ENDE FÜGE HINWEIS IN XML =====================
                                    }
                                    break;


                                case "ballMill":
                                    if (shaftflag != null)
                                    {
                                        var valueshaftflag = shaftflag.Attributes["value"].Value;

                                        if (valueshaftflag == "1")
                                        {
                                            _ = sb.Append("\n" + " --> BUG-CHECK:          Schaft-Check --> all is good");
                                        }
                                        else
                                        {
                                            _ = sb.Append("\n" + " --> BUG-CHECK:          !!! ATTENTION !!! Schaft nicht aktiviert");

                                            // ====================  START FÜGE HINWEIS IN XML =====================
                                            // Lese bestehenden Werkzeugnamen
                                            XmlNode noderead2 = xmlDoc.SelectSingleNode("omtdx/ncTools/ncTools/ncTools/ncTool");
                                            XmlNode noderead3 = xmlDoc.SelectSingleNode("omtdx/ncTools/ncTools/ncTools/ncTools/ncTool");
                                            if (noderead2 != null)
                                            {
                                                var bNcname = noderead2.Attributes["name"].Value;
                                                // Schreibe neuen Werkzeugnamen
                                                XmlNode nodewrite = xmlDoc.SelectSingleNode("omtdx/ncTools/ncTools/ncTools/ncTool");
                                                nodewrite.Attributes[2].Value = "!! ATTENTION !!! Schaft FEHLT" + " // " + bNcname;
                                            }
                                            else if (noderead3 != null)  // (notwedig falls in Feature Statusordner ein Ordner hinzugefügt wurde)
                                            {
                                                var bNcname = noderead3.Attributes["name"].Value;
                                                // Schreibe neuen Werkzeugnamen
                                                XmlNode nodewrite = xmlDoc.SelectSingleNode("omtdx/ncTools/ncTools/ncTools/ncTools/ncTool");
                                                nodewrite.Attributes[2].Value = "!! ATTENTION !!! Schaft FEHLT" + " // " + bNcname;
                                            }
                                            else
                                            {
                                                _ = sb.Append("\n" + " --> BUG-CHECK:          !!! ERROR !!! Schreiben in XML fehlgeschlagen - Knoten nicht vorhanden");
                                            }
                                            // ==================== ENDE FÜGE HINWEIS IN XML =====================
                                        }
                                    }
                                    else
                                    {
                                        _ = sb.Append("\n" + " --> BUG-CHECK:          !!! ATTENTION !!! Schaftknoten in XML fehlt");

                                        // ====================  START FÜGE HINWEIS IN XML =====================
                                        // Lese bestehenden Werkzeugnamen
                                        XmlNode noderead2 = xmlDoc.SelectSingleNode("omtdx/ncTools/ncTools/ncTools/ncTool");
                                        XmlNode noderead3 = xmlDoc.SelectSingleNode("omtdx/ncTools/ncTools/ncTools/ncTools/ncTool");
                                        if (noderead2 != null)
                                        {
                                            var bNcname = noderead2.Attributes["name"].Value;
                                            // Schreibe neuen Werkzeugnamen
                                            XmlNode nodewrite = xmlDoc.SelectSingleNode("omtdx/ncTools/ncTools/ncTools/ncTool");
                                            nodewrite.Attributes[2].Value = "!! ATTENTION !!! Schaft FEHLT" + " // " + bNcname;
                                        }
                                        else if (noderead3 != null)  // (notwedig falls in Feature Statusordner ein Ordner hinzugefügt wurde)
                                        {
                                            var bNcname = noderead3.Attributes["name"].Value;
                                            // Schreibe neuen Werkzeugnamen
                                            XmlNode nodewrite = xmlDoc.SelectSingleNode("omtdx/ncTools/ncTools/ncTools/ncTools/ncTool");
                                            nodewrite.Attributes[2].Value = "!! ATTENTION !!! Schaft FEHLT" + " // " + bNcname;
                                        }
                                        else
                                        {
                                            _ = sb.Append("\n" + " --> BUG-CHECK:          !!! ERROR !!! Schreiben in XML fehlgeschlagen - Knoten nicht vorhanden");
                                        }
                                        // ==================== ENDE FÜGE HINWEIS IN XML =====================
                                    }
                                    break;


                                case "drilTool":
                                    if (shaftflag != null)
                                    {
                                        var valueshaftflag = shaftflag.Attributes["value"].Value;

                                        if (valueshaftflag == "1")
                                        {
                                            _ = sb.Append("\n" + " --> BUG-CHECK:          Schaft-Check --> all is good");
                                        }
                                        else
                                        {
                                            _ = sb.Append("\n" + " --> BUG-CHECK:          !!! ATTENTION !!! Schaft nicht aktiviert");

                                            // ====================  START FÜGE HINWEIS IN XML =====================
                                            // Lese bestehenden Werkzeugnamen
                                            XmlNode noderead2 = xmlDoc.SelectSingleNode("omtdx/ncTools/ncTools/ncTools/ncTool");
                                            XmlNode noderead3 = xmlDoc.SelectSingleNode("omtdx/ncTools/ncTools/ncTools/ncTools/ncTool");
                                            if (noderead2 != null)
                                            {
                                                var bNcname = noderead2.Attributes["name"].Value;
                                                // Schreibe neuen Werkzeugnamen
                                                XmlNode nodewrite = xmlDoc.SelectSingleNode("omtdx/ncTools/ncTools/ncTools/ncTool");
                                                nodewrite.Attributes[2].Value = "!! ATTENTION !!! Schaft FEHLT" + " // " + bNcname;
                                            }
                                            else if (noderead3 != null)  // (notwedig falls in Feature Statusordner ein Ordner hinzugefügt wurde)
                                            {
                                                var bNcname = noderead3.Attributes["name"].Value;
                                                // Schreibe neuen Werkzeugnamen
                                                XmlNode nodewrite = xmlDoc.SelectSingleNode("omtdx/ncTools/ncTools/ncTools/ncTools/ncTool");
                                                nodewrite.Attributes[2].Value = "!! ATTENTION !!! Schaft FEHLT" + " // " + bNcname;
                                            }
                                            else
                                            {
                                                _ = sb.Append("\n" + " --> BUG-CHECK:          !!! ERROR !!! Schreiben in XML fehlgeschlagen - Knoten nicht vorhanden");
                                            }
                                            // ==================== ENDE FÜGE HINWEIS IN XML =====================
                                        }
                                    }
                                    else
                                    {
                                        _ = sb.Append("\n" + " --> BUG-CHECK:          !!! ATTENTION !!! Schaftknoten in XML fehlt");

                                        // ====================  START FÜGE HINWEIS IN XML =====================
                                        // Lese bestehenden Werkzeugnamen
                                        XmlNode noderead2 = xmlDoc.SelectSingleNode("omtdx/ncTools/ncTools/ncTools/ncTool");
                                        XmlNode noderead3 = xmlDoc.SelectSingleNode("omtdx/ncTools/ncTools/ncTools/ncTools/ncTool");
                                        if (noderead2 != null)
                                        {
                                            var bNcname = noderead2.Attributes["name"].Value;
                                            // Schreibe neuen Werkzeugnamen
                                            XmlNode nodewrite = xmlDoc.SelectSingleNode("omtdx/ncTools/ncTools/ncTools/ncTool");
                                            nodewrite.Attributes[2].Value = "!! ATTENTION !!! Schaft FEHLT" + " // " + bNcname;
                                        }
                                        else if (noderead3 != null)  // (notwedig falls in Feature Statusordner ein Ordner hinzugefügt wurde)
                                        {
                                            var bNcname = noderead3.Attributes["name"].Value;
                                            // Schreibe neuen Werkzeugnamen
                                            XmlNode nodewrite = xmlDoc.SelectSingleNode("omtdx/ncTools/ncTools/ncTools/ncTools/ncTool");
                                            nodewrite.Attributes[2].Value = "!! ATTENTION !!! Schaft FEHLT" + " // " + bNcname;
                                        }
                                        else
                                        {
                                            _ = sb.Append("\n" + " --> BUG-CHECK:          !!! ERROR !!! Schreiben in XML fehlgeschlagen - Knoten nicht vorhanden");
                                        }
                                        // ==================== ENDE FÜGE HINWEIS IN XML =====================
                                    }
                                    break;

                                default:

                                    break;
                            }

                        }

                        xmlDoc.Save(path1);


                        // Axialen Vorschub prüfen





                    }

                    // ================================================================================FEATURE 8 (Status Ordner) 
                    if (Settings.Default.optionsT1_Feature8_check == true)
                    {
                        XmlDocument xmlDoc = new();
                        xmlDoc.Load(path1);             // xml laden

                        XmlNode noderead1 = xmlDoc.SelectSingleNode("/omtdx/ncTools/ncTools/ncTools/ncTool/customData/param[@name='Werkzeugstatus']");

                        string folderspezial = "SONDERWKZS (Bestand prüfen)";

                        if (noderead1 != null)
                        {
                            var Status = noderead1.Attributes["value"].Value;

                            switch (Status)
                            {
                                case "Freigegeben":
                                    _ = sb.Append("\n" + " --> STATUS-ORDNER:      Status Freigegeben gefunden -> wird nicht in Ordner '" + folderspezial + "' hinzugefügt");
                                    break;


                                case "FAVORIT":
                                    _ = sb.Append("\n" + " --> STATUS-ORDNER:      Klasse FAVOURIT gefunden -> wird nicht in Ordner '" + folderspezial + "' hinzugefügt");
                                    break;



                                default:

                                    // nodepath
                                    XmlNode root = xmlDoc.SelectSingleNode("omtdx/ncTools");

                                    //Create a deep clone.  The cloned node
                                    //includes the child nodes.
                                    XmlNode deep = root.CloneNode(true);

                                    //Add the deep clone to the document.
                                    root.InsertBefore(deep, root.FirstChild);

                                    //remove the old node
                                    root.RemoveChild(root.LastChild);

                                    //Create a new attribute.
                                    XmlNode root1 = xmlDoc.SelectSingleNode("omtdx/ncTools/ncTools");
                                    string ns = root1.GetNamespaceOfPrefix("ncTools");
                                    XmlNode attr = xmlDoc.CreateNode(XmlNodeType.Attribute, "folder", ns);
                                    attr.Value = folderspezial;

                                    //Add the attribute to the document.
                                    root1.Attributes.SetNamedItem(attr);


                                    _ = sb.Append("\n" + " --> STATUS-ORDNER:      Sonderstatus gefunden -> in Ordner '" + folderspezial + "' hinzugefügt");

                                    break;

                            }

                            xmlDoc.Save(path1);
                        }
                    }

                    // ================================================================================FEATURE 9 (Adaptor ISO old DB) 
                    if (Settings.Default.optionsT1_Feature9_check == true)
                    {
                        XmlDocument xmlDoc = new();
                        xmlDoc.Load(path1);             // xml laden

                        XmlNode coupling = xmlDoc.SelectSingleNode("/omtdx/holders/holder/coupling[@type='isoAdaptor']");
                        XmlNode node = xmlDoc.SelectSingleNode("/omtdx/holders/holder");

                        if (node != null)  // Abfrage ob Halterknoten in XML existiert
                        {

                            if (coupling == null)
                            {

                                // COUPLING DEFINITION IN XML
                                string COUP = COUPLING(path1);
                                string COUPISO = COUPLINGISO(path1);



                                //Create a new node (couplings)
                                XmlNode noderead1 = xmlDoc.SelectSingleNode("/omtdx");   // zum Knoten navigieren
                                XmlElement elem1 = xmlDoc.CreateElement("couplings");    // Knoten erstellen
                                noderead1.InsertBefore(elem1, noderead1.LastChild);      // Knoten einfügen


                                //Create a new node (coupling)
                                XmlNode noderead2 = xmlDoc.SelectSingleNode("/omtdx/couplings"); // zum Knoten navigieren
                                XmlElement elem2 = xmlDoc.CreateElement("coupling");             // Knoten erstellen
                                noderead2.InsertBefore(elem2, noderead2.LastChild);              // Knoten einfügen
                                                                                                 // Create new Attribute
                                XmlNode noderead22 = xmlDoc.SelectSingleNode("/omtdx/couplings/coupling");    // zum Knoten navigieren
                                XmlAttribute attr1 = xmlDoc.CreateAttribute("type");                          // Attribut estellen
                                attr1.Value = "isoAdaptor";                                                   // Wert des Attributes erstellen
                                noderead22.Attributes.SetNamedItem(attr1);                                    // Attribut mit Wert einfügen



                                //Create a new node (param)
                                XmlNode noderead3 = xmlDoc.SelectSingleNode("/omtdx/couplings/coupling");
                                XmlElement elem3 = xmlDoc.CreateElement("param");
                                noderead3.InsertBefore(elem3, noderead3.FirstChild);
                                // Create new Attribute
                                XmlNode noderead33 = xmlDoc.SelectSingleNode("/omtdx/couplings/coupling/param");
                                XmlAttribute attr2 = xmlDoc.CreateAttribute("name");
                                attr2.Value = "lengthOfUnit";
                                noderead33.Attributes.SetNamedItem(attr2);
                                // Create new Attribute2
                                XmlNode noderead333 = xmlDoc.SelectSingleNode("/omtdx/couplings/coupling/param");
                                XmlAttribute attr3 = xmlDoc.CreateAttribute("value");
                                attr3.Value = "mm";
                                noderead333.Attributes.SetNamedItem(attr3);


                                //Create a new node (param)
                                XmlNode noderead4 = xmlDoc.SelectSingleNode("/omtdx/couplings/coupling");
                                XmlElement elem4 = xmlDoc.CreateElement("param");
                                noderead4.InsertBefore(elem4, noderead4.FirstChild);
                                // Create new Attribute
                                XmlNode noderead44 = xmlDoc.SelectSingleNode("/omtdx/couplings/coupling/param");
                                XmlAttribute attr4 = xmlDoc.CreateAttribute("name");
                                attr4.Value = "gagePointOffset";
                                noderead44.Attributes.SetNamedItem(attr4);
                                // Create new Attribute2
                                XmlNode noderead444 = xmlDoc.SelectSingleNode("/omtdx/couplings/coupling/param");
                                XmlAttribute attr44 = xmlDoc.CreateAttribute("value");
                                attr44.Value = "0";
                                noderead444.Attributes.SetNamedItem(attr44);


                                //Create a new node (param)
                                XmlNode noderead5 = xmlDoc.SelectSingleNode("/omtdx/couplings/coupling");
                                XmlElement elem5 = xmlDoc.CreateElement("param");
                                noderead5.InsertBefore(elem5, noderead5.FirstChild);
                                // Create new Attribute
                                XmlNode noderead55 = xmlDoc.SelectSingleNode("/omtdx/couplings/coupling/param");
                                XmlAttribute attr5 = xmlDoc.CreateAttribute("name");
                                attr5.Value = "isoCode";
                                noderead55.Attributes.SetNamedItem(attr5);
                                // Create new Attribute2
                                XmlNode noderead555 = xmlDoc.SelectSingleNode("/omtdx/couplings/coupling/param");
                                XmlAttribute attr55 = xmlDoc.CreateAttribute("value");
                                attr55.Value = COUPISO;
                                noderead555.Attributes.SetNamedItem(attr55);



                                //Create a new node (param)
                                XmlNode noderead6 = xmlDoc.SelectSingleNode("/omtdx/couplings/coupling");
                                XmlElement elem6 = xmlDoc.CreateElement("param");
                                noderead6.InsertBefore(elem6, noderead6.FirstChild);
                                // Create new Attribute
                                XmlNode noderead66 = xmlDoc.SelectSingleNode("/omtdx/couplings/coupling/param");
                                XmlAttribute attr6 = xmlDoc.CreateAttribute("name");
                                attr6.Value = "class";
                                noderead66.Attributes.SetNamedItem(attr6);
                                // Create new Attribute2
                                XmlNode noderead666 = xmlDoc.SelectSingleNode("/omtdx/couplings/coupling/param");
                                XmlAttribute attr66 = xmlDoc.CreateAttribute("value");
                                attr66.Value = COUP;
                                noderead666.Attributes.SetNamedItem(attr66);



                                // COUPLING Aufruf IN XML



                                // Change TYPE ATTRIBUT
                                XmlNode nodereadXXX = xmlDoc.SelectSingleNode("/omtdx/holders/holder/coupling");
                                nodereadXXX.Attributes[2].Value = "isoAdaptor";

                                // Change TYPE ATTRIBUT
                                XmlNode nodereadXXXX = xmlDoc.SelectSingleNode("/omtdx/holders/holder/coupling");
                                nodereadXXXX.Attributes[0].Value = COUP;

                                // ADD iso CODE ATTRIBUT
                                XmlAttribute attrXXX = xmlDoc.CreateAttribute("isoCode");
                                attrXXX.Value = COUPISO;
                                nodereadXXX.Attributes.SetNamedItem(attrXXX);



                                // TEXT fuer LOG
                                _ = sb.Append("\n" + " --> ISO coupling generated: " + COUP + " -- " + COUPISO);
                            }

                            else
                            {
                                _ = sb.Append("\n" + " --> ISO coupling already exists !!!!!");
                            }
                        }

                        else  // Halter existiert nicht
                        {
                            // TEXT fuer LOG
                            _ = sb.Append("\n" + " --> ISO coupling: Holder element does not exist - coupling cannot be created!");
                        }

                        xmlDoc.Save(path1);

                    }

                    // ================================================================================FEATURE 10 (SPLIT NAME old DB) 
                    if (Settings.Default.optionsT1_Feature10_check == true)
                    {
                        XmlDocument xmlDoc = new();
                        xmlDoc.Load(path1);             // xml laden



                        // Lese bestehenden Werkzeugnamen
                        XmlNode node = xmlDoc.SelectSingleNode("omtdx/ncTools/ncTools/ncTool");


                        if (node != null)
                        {
                            var bNcname = node.Attributes["name"].Value;

                            string str = bNcname.ToString();


                            String[] spearator = { " -- "};



                            if (str.Contains(" -- "))   // Abfrage ob String überhaupt vorhanden ist
                            {

                                // using the method
                                String[] strlist = str.Split(spearator,
                                   StringSplitOptions.RemoveEmptyEntries);


                                if (strlist[0] != null)
                                {
                                    // Schreibe neuen Werkzeugnamen
                                    node.Attributes[1].Value = strlist[0];
                                    _ = sb.Append("\n" + " --> SPILT NAME: NameWkz geändert auf -> " + strlist[0]);
                                }
                                else
                                {
                                    _ = sb.Append("\n" + " --> SPLIT NAME do not works");
                                }



                                if (strlist[1] != null)
                                {
                                    //Create a new node (coupling)
                                    XmlNode noderead2 = xmlDoc.SelectSingleNode("/omtdx/ncTools/ncTools/ncTool"); // zum Knoten navigieren
                                    XmlElement elem2 = xmlDoc.CreateElement("param");             // Knoten erstellen
                                    noderead2.InsertBefore(elem2, noderead2.FirstChild);              // Knoten einfügen

                                    XmlNode noderead22 = xmlDoc.SelectSingleNode("/omtdx/ncTools/ncTools/ncTool/param");    // zum Knoten navigieren
                                    XmlAttribute attr1 = xmlDoc.CreateAttribute("name");                          // Attribut estellen
                                    attr1.Value = "comment";                                                   // Wert des Attributes erstellen
                                    noderead22.Attributes.SetNamedItem(attr1);                                    // Attribut mit Wert einfügen

                                    XmlNode noderead222 = xmlDoc.SelectSingleNode("/omtdx/ncTools/ncTools/ncTool/param");    // zum Knoten navigieren
                                    XmlAttribute attr2 = xmlDoc.CreateAttribute("value");                          // Attribut estellen
                                    attr2.Value = strlist[1];                                                   // Wert des Attributes erstellen
                                    noderead222.Attributes.SetNamedItem(attr2);


                                    _ = sb.Append("\n" + " --> SPILT NAME: Kommentar hinzugefügt -> " + strlist[1]);
                                }

                                else
                                {
                                    _ = sb.Append("\n" + " --> SPLIT NAME do not works");
                                }
                            }


                            else
                            {
                                 _ = sb.Append("\n" + " --> SPLIT NAME do not works --> comment does not exist");
                            }


                        }
                        else 
                        {
                            _ = sb.Append("\n" + " --> SPLIT NAME do not works" );
                        }

                        xmlDoc.Save(path1);
                    }



                    // ================================================================================verschiebe Datei

                            if (Directory.Exists(TARGETXML))
                    {
                        File.Move(xmlList[0], @TARGETXML + filename, true);
                        _ = sb.Append("\n" + " --> File moved to:      " + @TARGETXML);
                    }
                    else
                    {
                        Directory.CreateDirectory(@TARGETXML);
                        File.Move(xmlList[0], @TARGETXML + filename, true);
                        _ = sb.Append("\n" + " --> Created Directory      " + @TARGETXML + " and moved File");
                    }

                    // ==================================================================================== FINI 
                    _ = sb.Append("\n" + "\n" + "============================  Fini " + filename + "  ========================== \n");


                    // schreibe Infos in settingsdatei (für Ausgabefenster)
                    string datetime = DateTime.Now.ToString();
                    StringBuilder sb2 = new();
                    _ = sb2.Append("\n" + datetime + "\n" + sb);
                    Settings.Default.syncxml_Info = sb2.ToString();


                    // infos in log schreiben
                    string logcontent = (sb.ToString());
                    // Erstelle Log-Objekt  (Parameter: Pfad/Dateiname/Inhalt)
                    Log logger1 = new Log(@Settings.Default.optionsT1_destination + "log_sync_xml/", filnamewithoutExtension + ".log", logcontent);
                    logger1.Logmethod();

                    // Log Eintrag in Liste hinzu
                    Task.Run(() =>
                    {
                        Dispatcher.Invoke(() =>
                        {
                            LogINIT();
                        });
                    });

                    anzahlxml--;
                }
            }
            // =======================================================================    Fehler abfangen    =========================================================================================
            catch (Exception u)
            {
                _ = MessageBox.Show("" + u);
            }
        }


        public static string COUPLING (string path1)
        {

            XmlDocument xmlDoc = new();
            xmlDoc.Load(path1);             // xml laden


            XmlNode coupling40 = xmlDoc.SelectSingleNode("/omtdx/holders/holder/coupling[@class='HSK40']");
            XmlNode coupling63 = xmlDoc.SelectSingleNode("/omtdx/holders/holder/coupling[@class='HSK63']");
            XmlNode coupling100 = xmlDoc.SelectSingleNode("/omtdx/holders/holder/coupling[@class='HSK100']");

            string COUPLINGmachine ="";

            if (coupling40 != null)
            {
                COUPLINGmachine = "HSK-E 40";
            }
            else if (coupling63 != null)
            {
                COUPLINGmachine = "HSK63";
            }
            else if (coupling100 != null)
            {
                COUPLINGmachine = "HSK100";
            }
            else
            {

            }

            return COUPLINGmachine;
        }
        public static string COUPLINGISO(string path1)
        {

            XmlDocument xmlDoc = new();
            xmlDoc.Load(path1);             // xml laden


            XmlNode coupling40 = xmlDoc.SelectSingleNode("/omtdx/holders/holder/coupling[@class='HSK40']");
            XmlNode coupling63 = xmlDoc.SelectSingleNode("/omtdx/holders/holder/coupling[@class='HSK63']");
            XmlNode coupling100 = xmlDoc.SelectSingleNode("/omtdx/holders/holder/coupling[@class='HSK100']");

            string COUPLINGmachineISO = "";

            if (coupling40 != null)
            {
                COUPLINGmachineISO = "HSK03C0400$$$$";
            }
            else if (coupling63 != null)
            {
                COUPLINGmachineISO = "HSK01C0630$$$$";
            }
            else if (coupling100 != null)
            {
                COUPLINGmachineISO = "HSK01C1000$$$$";
            }
            else
            {

            }

            return  COUPLINGmachineISO;
        }


        private void btn_stop_sync_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // Begin watching.      
                FSW.EnableRaisingEvents = false;

                // Buttons available
                btn_Start_sync.IsEnabled = true;
                btn_stop_sync.IsEnabled = false;
                Grid_Setting.IsEnabled = true;


                // write Status to xaml
                status.Content = "FILEWATCHER STOPPED";
                status.Foreground = new SolidColorBrush(Color.FromArgb(0xFF, 0xD8, 0x96, 0x47));
            }
            catch (Exception u)
            {
                MessageBox.Show("" + u);
            }
        }

        private void LogINIT()
        {
            lv.Items.Clear();

            string LOGDIRECTORY = Settings.Default.optionsT1_destination + "/log_sync_xml";

            if (Directory.Exists(LOGDIRECTORY))
            {

                // Take a snapshot of the file system.  
                DirectoryInfo dir = new DirectoryInfo(LOGDIRECTORY);

                // This method assumes that the application has discovery permissions  
                // for all folders under the specified path.  
                IEnumerable<FileInfo> fileList = dir.GetFiles("*.*", SearchOption.AllDirectories);

                //Create the query  
                IEnumerable<FileInfo> fileQuery =
                    from file in fileList
                    where file.Extension == ".log"
                    orderby file.LastAccessTime
                    select file;

                //Execute the query. This might write out a lot of files!  
                foreach (FileInfo fi in fileQuery)
                {
                    //lv.Items.Add(fi.Name);
                    lv.Items.Add(new { Id = fi.Name, Date = fi.LastAccessTime });
                }

                // list View Date Descending
                lv.Items.SortDescriptions.Add(new SortDescription("Date", ListSortDirection.Descending));

            }
            else
            {

            }
        }

        private void ListViewItem_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            try
            {
                string input = lv.SelectedItems[0].ToString();
                string sPattern = "[0-9]{6}";

                Regex rgx = new Regex(sPattern);
                foreach (Match match in rgx.Matches(input))
                {
                    string v = match.Value;

                    string LOGDIRECTORY = Settings.Default.optionsT1_destination + "/log_sync_xml";
                    if (Directory.Exists(LOGDIRECTORY))
                    {

                        DirectoryInfo dir = new DirectoryInfo(LOGDIRECTORY);
                        foreach (var fi in dir.GetFiles(v + ".log"))
                        {
                            string logcontent = File.ReadAllText(LOGDIRECTORY + "/" + v + ".log");

                            Settings.Default.syncxml_Info = logcontent;
                            tb_AusgabeDBINFO.Foreground = new SolidColorBrush(Color.FromArgb(0xFF, 0xD8, 0x96, 0x47));

                        }
                    }
                    else { }
                }
            }

            catch (Exception u)
            {
                _ = MessageBox.Show("" + u);
            }
        }

        private void btn_showlog_Click(object sender, RoutedEventArgs e)
        {
            try
            {


                if (Directory.Exists(Settings.Default.optionsT1_destination + "log_sync_xml/"))
                {
                    Process.Start("explorer.exe", Settings.Default.optionsT1_destination + "log_sync_xml");
                }
                else
                {
                    Directory.CreateDirectory(Settings.Default.optionsT1_destination + "log_sync_xml/");
                    Process.Start("explorer.exe", Settings.Default.optionsT1_destination + "log_sync_xml");
                }



            }
            catch (Exception u)
            {
                _ = MessageBox.Show("" + u);
            }
        }

        #endregion ==============================================XML-sync================================================



        #region ==============================================VC Parser===============================================
        private void Btn_SelectFile_Click(object sender, RoutedEventArgs e)
        {
            // Create OpenFileDialog
            Microsoft.Win32.OpenFileDialog openFileDlg = new();

            // Launch OpenFileDialog by calling ShowDialog method
            bool? result = openFileDlg.ShowDialog();
            // Get the selected file name and display in a TextBox.
            // Load content of file in a TextBlock
            if (result == true)
            {
                Tb_File.Text = openFileDlg.FileName;
                //TextBlock1.Text = System.IO.File.ReadAllText(openFileDlg.FileName);
            }
        }

        private void Btn_Parse_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Btn_Parse.IsEnabled = false;
                tb_AusgabeVCINFO.Text = "";


                string file = Tb_File.Text;
                string line;






                // open temp and do something
                int counter1 = 0;
                using (StreamReader sr = new(file))
                {
                    while ((line = sr.ReadLine()) != null)
                    {
                        counter1++;

                        if (Regex.IsMatch(line, "(TOOL CALL)", RegexOptions.IgnoreCase))
                        {
                            string sea = line;
                            string sPatternID = "[0-9]{6}";   // Filter ID
                            string sPatternn = "S[0-9]{1,8}";   // Filter n

                            Regex rgx = new Regex(sPatternID);
                            foreach (Match match in rgx.Matches(sea))
                            {
                                string v = match.Value;
                                tb_AusgabeVCINFO.Inlines.Add(new Run("\n" + "\n" + "''" + v + "''") { Foreground = new SolidColorBrush(Color.FromArgb(0xFF, 0xD8, 0x96, 0x47)), TextDecorations = TextDecorations.Underline });
                            }

                            Regex rgx1 = new Regex(sPatternn);
                            foreach (Match match in rgx1.Matches(sea))
                            {
                                string v = match.Value;
                                tb_AusgabeVCINFO.Inlines.Add(new Run("   " + v + "\n") { Foreground = Brushes.Red, FontWeight = FontWeights.Bold });
                            }

                        }



                        if (Regex.IsMatch(line, "([*] -)", RegexOptions.IgnoreCase))
                        {
                            string sea = line;

                            string resultDeleteNr = sea.TrimStart(new char[] { '1', '2', '3', '4', '5', '6', '7', '8', '9', '0', ' ' });

                            tb_AusgabeVCINFO.Inlines.Add(new Run(resultDeleteNr + "\n"));
                        }


                        if (Regex.IsMatch(line, "(FN.*Q10[=| ])", RegexOptions.IgnoreCase))
                        {
                            string sea = line;
                            string sPatternXY = "Q10[=+ ]{0,10}[0-9]{0,8}";   // Filter XY

                            Regex rgx = new Regex(sPatternXY);
                            foreach (Match match in rgx.Matches(sea))
                            {
                                string v = match.Value;
                                tb_AusgabeVCINFO.Inlines.Add(new Run(v + "\n") { Foreground = Brushes.Yellow });
                            }


                        }

                        if (Regex.IsMatch(line, "(FN.*Q11[=| ])", RegexOptions.IgnoreCase))
                        {
                            string sea = line;
                            string sPatternZ = "Q11[=+ ]{0,10}[0-9]{0,8}";   // Filter Z

                            Regex rgx = new Regex(sPatternZ);
                            foreach (Match match in rgx.Matches(sea))
                            {
                                string v = match.Value;
                                tb_AusgabeVCINFO.Inlines.Add(new Run(v + "\n") { Foreground = Brushes.Yellow });
                            }


                        }

                        if (Regex.IsMatch(line, "(FN.*Q12[=| ])", RegexOptions.IgnoreCase))
                        {
                            string sea = line;
                            string sPatternred = "Q12[=+ ]{0,10}[0-9]{0,8}";   // Filter red

                            Regex rgx = new Regex(sPatternred);
                            foreach (Match match in rgx.Matches(sea))
                            {
                                string v = match.Value;
                                tb_AusgabeVCINFO.Inlines.Add(new Run(v + "\n") { Foreground = Brushes.Yellow });
                            }

                        }

                        if (Regex.IsMatch(line, "(Q206[=| ])", RegexOptions.IgnoreCase))
                        {
                            string sea = line;
                            string sPatternBof = "Q206[=+ ]{0,10}[0-9]{0,8}";   // Bof

                            Regex rgx = new Regex(sPatternBof);
                            foreach (Match match in rgx.Matches(sea))
                            {
                                string v = match.Value;
                                tb_AusgabeVCINFO.Inlines.Add(new Run(v + "\n") { Foreground = new SolidColorBrush(Color.FromArgb(0xFF, 0xD8, 0x96, 0x47)) });
                            }

                        }

                        if (Regex.IsMatch(line, "(Q202[=| ])", RegexOptions.IgnoreCase))
                        {
                            string sea = line;
                            string sPatternapbo = "Q202[=+ ]{0,10}[0-9]{0,8}";   // ap bo

                            Regex rgx = new Regex(sPatternapbo);
                            foreach (Match match in rgx.Matches(sea))
                            {
                                string v = match.Value;
                                tb_AusgabeVCINFO.Inlines.Add(new Run(v + "\n") { Foreground = Brushes.GreenYellow, FontWeight = FontWeights.Bold });
                            }

                        }


                        else { }


                    }
                }


                Btn_Parse.IsEnabled = true;

            }

            catch (Exception ee)
            {
                MessageBox.Show("" + ee);
                Btn_Parse.IsEnabled = true;
            }
        }





        #endregion ===========================================VC Parser===============================================



        #region ==============================================  NC REWORK  ===============================================


        private void Btn_START_Click(object sender, RoutedEventArgs e)
        {
            try
            {

                Btn_START.IsEnabled = false;

                string ROOTH = @Settings.Default.optionsT3_Feature6;                    // Wurzelverzeichis der zu ladenden .H Dateien
                string[] HListEXIST = Directory.GetFiles(ROOTH, "*" + Tb_File.Text);    // Array erstellen von allen .H Dateien im Verzeichnis
                int anzahlH = HListEXIST.GetLength(0);                                  // Anzahl der Elemente im Array ermitteln

                // Set Value Progressbar  (number of lines)
                Pb_ProgressBar_NC.Maximum = anzahlH;


                // call worker for work and update progressbar
                worker.RunWorkerAsync();

                //Pb_ProgressBar.IsIndeterminate = false;



            }

            catch (Exception ee)
            {
                MessageBox.Show("" + ee);
            }
        }


        void worker_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {


                string ROOTH = @Settings.Default.optionsT3_Feature6;                                           // Wurzelverzeichis der zu ladenden .H Dateien
                string[] HListEXIST = Directory.GetFiles(ROOTH, "*" + Settings.Default.optionsT3_Feature7);    // Array erstellen von allen .H Dateien im Verzeichnis
                int anzahlH = HListEXIST.GetLength(0);                                                         // Anzahl der Elemente im Array ermitteln
                int counterM128 = 0;
                int counterPB = 0;

                //MessageBox.Show(anzahlH + " .H Dateien gefunden");


                foreach (string dr in HListEXIST)                                       // für jedes Element .H im Wurzelverzeichnis
                {
                    counterPB++;

                    StringBuilder sb1 = new StringBuilder();
                    StringBuilder sblogger = new StringBuilder();
                    StringBuilder sblogger1 = new StringBuilder();
                    StreamReader sr1 = new StreamReader(dr);




                    // Datei auf M128 durchsuchen
                    bool M128 = false;
                    string lineM128;

                    while ((lineM128 = sr1.ReadLine()) != null)
                    {
                        if (Regex.IsMatch(lineM128, "(M 128|M128|FUNCTION TCPM)", RegexOptions.IgnoreCase))
                        {
                            M128 = true;
                        }
                    }

                    sr1.Close();







                    StreamReader sr2 = new StreamReader(dr);
                    sblogger.Append(dr + "\n");


                    // 1ste Zeile lesen und schreiben ------------------------------------------------------------------------
                    for (int i = 0; i < 1; i = i + 1)
                    {
                        string line = sr2.ReadLine();
                        sb1.Append(line + "\n");
                    }

                    // VC100 Kommentar hinzu ------------------------------------------------------------------------
                    if (Settings.Default.optionsT3_Feature1_check == true)
                    {
                        string addCommentVC100 = "; ******************************************\n" +
                                                  "; ACHTUNG VORSCHUEBE ANPASSEN / PROGRAMM ZULETZT MIT 150Prozent VORSCHUB GELAUFEN\n" +
                                                  "; KOMMENTAR LOESCHEN WENN PROGRAMM UMGESCHRIEBEN IST\n" +
                                                  "; ******************************************";
                        sb1.Append(addCommentVC100 + "\n");
                        sblogger.Append("VC100 Kommentar hinzugefügt" + "\n");
                    }

                    // Modulo Kommentar hinzu ------------------------------------------------------------------------
                    if (Settings.Default.optionsT3_Feature2_check == true)
                    {
                        if (M128 == true)
                        {
                            counterM128++;
                            string addCommentmodulo = "; ******************************************\n" +
                                                      "; ACHTUNG KEIN MODULO PGM -- Programm in BUERO pruefen lassen\n" +
                                                      "; KOMMENTAR LOESCHEN WENN PROGRAMM ERFOLGREICH GELAUFEN IST\n" +
                                                      "; ******************************************";

                            sb1.Append(addCommentmodulo + "\n");
                            sblogger.Append("!!!! KEIN MODULO PGM !!!! PROGRAMM PRUEFEN " + "\n");

                            string filename = System.IO.Path.GetFileName(dr); // Dateinamen aus Pfad
                            sblogger1.Append(filename);
                        }


                    }

                    // Restliche Zeilen ab Pos 1 lesen und schreiben ------------------------------------------------------------------------

                    string line1;
                    int lineCounter = 0;

                    while ((line1 = sr2.ReadLine()) != null)
                    {
                        if (lineCounter < 0)
                        {
                            lineCounter++;
                        }
                        else
                        {
                            sb1.Append(line1 + "\n");
                            lineCounter++;
                        }

                    }

                    sr2.Close();




                    // in Datei überschreiben und schließen
                    StreamWriter sw1 = new StreamWriter(dr);
                    sw1.WriteLine(sb1);
                    sw1.Close();


                    sblogger.Append("\n");


                    // Schreibe logfiles
                    File.AppendAllText(@Settings.Default.optionsT3_Feature5 + "MI_UPDATE_2022.log", sblogger + Environment.NewLine);
                    File.AppendAllText(@Settings.Default.optionsT3_Feature5 + "MI_UPDATE_2022_without_modulo.log", sblogger1 + Environment.NewLine);


                    (sender as BackgroundWorker).ReportProgress(counterPB);
                    Thread.Sleep(0);

                }


                Task.Run(() =>
                {
                    Dispatcher.Invoke(() =>
                    {
                        // Anzeigefenster
                        TB_info.Text = "Verzeichnis erfolgreich durchlaufen: " + anzahlH + " Programme mit " + Tb_File.Text + " gefunden \n!!! ACHTUNG es wurde(n) " + counterM128 + " Progamm(e) mit M128 gefunden -- PRUEFEN !!!";
                        Btn_START.IsEnabled = true;
                    });
                });



            }
            catch (Exception ee)
            {
                MessageBox.Show("" + ee);
            }
        }


        void worker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            Pb_ProgressBar_NC.Value = e.ProgressPercentage;
        }


        private void LOGS_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Process.Start("explorer.exe", @Settings.Default.optionsT3_Feature5);
            }
            catch (Exception ee)
            {

                MessageBox.Show("" + ee);
            }
        }

        #endregion ===========================================  NC REWORK  ===============================================



        #region ============================================== PROJEKT MANAGER ===============================================

        private static void ReadSingleRow(IDataRecord dataRecord)
        {
            Console.WriteLine(String.Format("{0}, {1}", dataRecord[0], dataRecord[1]));
        }


        #endregion ==============================================  PROJEKT MANAGER ===============================================







        #region ==============================================  SETTINGS ===============================================
        private void Btn_UPDATE_SQL_Click(object sender, RoutedEventArgs e)
        {
            //MessageBox.Show("Getting Connection ...");
            SqlConnection conn = DBUtils.GetDBConnection();

            try
            {
                //MessageBox.Show("Openning Connection ...");
                conn.Open();

                // Abfrage ob SQL verbindung erfolgreich war
                if (conn.State == ConnectionState.Open)
                {
                    var stm = "SELECT @@VERSION";
                    using var cmd = new SqlCommand(stm, conn);
                    string version = cmd.ExecuteScalar().ToString();
                    TB_STATUS_SQL.Text = "CONNECT";
                    TB_STATUS_SQL.Foreground = new SolidColorBrush(Color.FromArgb(0xFF, 0x32, 0xF1, 0x1D));   // #FF32F11D grün
                }

                else
                {
                    TB_STATUS_SQL.Text = "FAIL!";
                    TB_STATUS_SQL.Foreground = new SolidColorBrush(Color.FromArgb(0xFF, 0xFF, 0x2B, 0x2B));   // #FF FF 2B 2B rot
                }

            }

            catch (Exception)
            {
                // MessageBox.Show("" + e);
                TB_STATUS_SQL.Text = "FAIL!!";
                TB_STATUS_SQL.Foreground = new SolidColorBrush(Color.FromArgb(0xFF, 0xFF, 0x2B, 0x2B));   // #FF FF 2B 2B rot
            }
            finally
            {
                // die Verbindung schließen.
                conn.Close();
                // das Objekt absagen, die Ressourcen freien.
                conn.Dispose();
                conn = null;
            }
        }
        private void CHECK_SQL_Click(object sender, RoutedEventArgs e)
        {
            //MessageBox.Show("Getting Connection ...");
            SqlConnection conn = DBUtils.GetDBConnection();

            try
            {
                //MessageBox.Show("Openning Connection ...");
                conn.Open();

                // Abfrage ob SQL verbindung erfolgreich war
                if (conn.State == ConnectionState.Open)
                {
                    var stm = "SELECT @@VERSION";
                    using var cmd = new SqlCommand(stm, conn);
                    string version = cmd.ExecuteScalar().ToString();
                    TB_STATUS_SQL.Text = "CONNECT";
                    TB_STATUS_SQL.Foreground = new SolidColorBrush(Color.FromArgb(0xFF, 0x32, 0xF1, 0x1D));   // #FF32F11D grün
                }

                else
                {
                    TB_STATUS_SQL.Text = "FAIL!";
                    TB_STATUS_SQL.Foreground = new SolidColorBrush(Color.FromArgb(0xFF, 0xFF, 0x2B, 0x2B));   // #FF FF 2B 2B rot
                }

            }

            catch (Exception)
            {
                // MessageBox.Show("" + e);
                TB_STATUS_SQL.Text = "FAIL!!";
                TB_STATUS_SQL.Foreground = new SolidColorBrush(Color.FromArgb(0xFF, 0xFF, 0x2B, 0x2B));   // #FF FF 2B 2B rot
            }
            finally
            {
                // die Verbindung schließen.
                conn.Close();
                // das Objekt absagen, die Ressourcen freien.
                conn.Dispose();
                conn = null;
            }
        }

        #endregion ==============================================  SETTINGS ===============================================


        #region ==============================================  ABOUT ===============================================
        public void Info()
        {
            try
            {
                // Assembly Info
                string version = Assembly.GetExecutingAssembly().GetName().Version.ToString();

                // Host Info
                string HostName = System.Net.Dns.GetHostName();
                IPHostEntry hostInfo = System.Net.Dns.GetHostEntry(HostName);
                //string Ipv4Adresse = hostInfo.AddressList[2].ToString();
                //string Ipv6Adresse = hostInfo.AddressList[0].ToString();

                string Host = "Hostname: " + HostName;

                Lbl_Assembly.Content = "Version: " + version;
                Lbl_Info.Content = Host;


            }
            catch (Exception u)
            {
                MessageBox.Show("" + u);
            }
        }



        // Open DownloadPage
        private void Hyperlink_RequestNavigate(object sender, RequestNavigateEventArgs e)
        {
            // open Browser

            Process myProcess = new Process();

            try
            {
                myProcess.StartInfo.UseShellExecute = true;
                myProcess.StartInfo.FileName = "https://github.com/StephanNirschl/MIM";
                myProcess.Start();

            }

            catch (Exception u)
            {
                MessageBox.Show("" + u);
            }
        }






        #endregion ==============================================ABOUT================================================


    }
}
