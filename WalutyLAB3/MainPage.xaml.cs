using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Xml.Linq;
using WalutyLAB3.Klasy;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

//Szablon elementu Pusta strona jest udokumentowany na stronie https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x415

namespace WalutyLAB3
{
    /// <summary>
    /// Pusta strona, która może być używana samodzielnie lub do której można nawigować wewnątrz ramki.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        List<PozycjaTabA> kursyWalut = new List<PozycjaTabA>();

        public MainPage()
        {
            this.InitializeComponent();
        }

        private async void Grid_Loaded(object sender, RoutedEventArgs e)
        {
            var klient = new HttpClient();

            var dane = await klient.GetStringAsync(new Uri(API_NBP.daneXML));

            var daneXML = XDocument.Parse(dane);

            foreach (var pozycja in daneXML.Descendants("pozycja"))
            {
                var pozycjaTabA = new PozycjaTabA()
                {
                    NazwaWaluty = pozycja.Element("nazwa_waluty").Value,
                    Przelicznik = pozycja.Element("przelicznik").Value,
                    KursSredni = pozycja.Element("kurs_sredni").Value,
                    KodWaluty = pozycja.Element("kod_waluty").Value
                };

                kursyWalut.Add(pozycjaTabA);
            }

            kursyWalut.Insert(0, new PozycjaTabA() { NazwaWaluty = "Polski Złoty", KodWaluty = "PLN", KursSredni = "1,0000", Przelicznik = "1" });


            WalutaWejscieLbx.ItemsSource = kursyWalut;
            WalutaWyjscieLbx.ItemsSource = kursyWalut;

        }
        
    }
}
