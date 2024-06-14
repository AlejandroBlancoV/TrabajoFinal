
using Prueba1.Backend.Equipos;
using Prueba1.Backend.Utilidades;
using System.Windows.Media.Imaging;

namespace Prueba1.Backend.Gestion
{
    internal class GestionEquipos
    {
        GestionJugadores gestionJugadores = new GestionJugadores();
        

        public Equipo CrearEquipo(String nombre, BitmapImage image, int presupuesto, bool controladoPorUsuario)
        {
            Plantilla plantilla = gestionJugadores.GenerarPlantillaPorDefecto();
            Alineacion alineacion = gestionJugadores.OrdenarAlineacion(plantilla);
            Equipo equipo = new Equipo(nombre, ImageUtils.ConvertirImagenAEscudo(image), alineacion, plantilla, presupuesto, controladoPorUsuario);
            return equipo;
        }

        public List<Equipo> GenerarEquiposLiga()
        {
            Equipo[] equipos = new Equipo[20];
            BitmapImage imagen = new BitmapImage();
            imagen.BaseUri = new Uri("pack://application:,,,/Images/Shields/CalizCF.png");
            equipos[0] = CrearEquipo("Cáliz CF",imagen,0,false);
            imagen.BaseUri = new Uri("pack://application:,,,/Images/Shields/CANovesuna.png");
            equipos[1] = CrearEquipo("CA Novesuna",imagen,0,false);
            imagen.BaseUri = new Uri("pack://application:,,,/Images/Shields/CedillaCF.png");
            equipos[2] = CrearEquipo("Cedilla CF",imagen,0,false);
            imagen.BaseUri = new Uri("pack://application:,,,/Images/Shields/ChironaFC.png");
            equipos[3] = CrearEquipo("Chirona FC",imagen,0,false);
            imagen.BaseUri = new Uri("pack://application:,,,/Images/Shields/CholoCF.png");
            equipos[4] = CrearEquipo("Cholo CF",imagen,0,false);
            imagen.BaseUri = new Uri("pack://application:,,,/Images/Shields/DeportivoPalaves.png");
            equipos[5] = CrearEquipo("Deportivo Palavés",imagen,0,false);
            imagen.BaseUri = new Uri("pack://application:,,,/Images/Shields/FrenadaCF.png");
            equipos[6] = CrearEquipo("Frenada CF",imagen,0,false);
            imagen.BaseUri = new Uri("pack://application:,,,/Images/Shields/GabarraFC.png");
            equipos[7] = CrearEquipo("Gabarra FC",imagen,0,false);
            imagen.BaseUri = new Uri("pack://application:,,,/Images/Shields/GalloVallecano.png");
            equipos[8] = CrearEquipo("Gallo Vallecano",imagen,0,false);
            imagen.BaseUri = new Uri("pack://application:,,,/Images/Shields/MerengueCF.png");
            equipos[9] = CrearEquipo("Merengue CF",imagen,0,false);
            imagen.BaseUri = new Uri("pack://application:,,,/Images/Shields/RCCruelta.png");
            equipos[10] = CrearEquipo("RC Cruelta",imagen,0,false);
            imagen.BaseUri = new Uri("pack://application:,,,/Images/Shields/RCDCayorca.png");
            equipos[11] = CrearEquipo("RCD Cayorca",imagen,0,false);
            imagen.BaseUri = new Uri("pack://application:,,,/Images/Shields/RealB.E.T.I.S.png");
            equipos[12] = CrearEquipo("RealB.E.T.I.S",imagen,0,false);
            imagen.BaseUri = new Uri("pack://application:,,,/Images/Shields/RealSuciedadCF.png");
            equipos[13] = CrearEquipo("Real Suciedad CF",imagen,0,false);
            imagen.BaseUri = new Uri("pack://application:,,,/Images/Shields/SetafeCF.png");
            equipos[14] = CrearEquipo("Setafe CF",imagen,0,false);
            imagen.BaseUri = new Uri("pack://application:,,,/Images/Shields/SpotYfaiMasiaFC.png");
            equipos[15] = CrearEquipo("SpotYfai Masia FC",imagen,0,false);
            imagen.BaseUri = new Uri("pack://application:,,,/Images/Shields/UDAlegria.png");
            equipos[16] = CrearEquipo("UD Alegría",imagen,0,false);
            imagen.BaseUri = new Uri("pack://application:,,,/Images/Shields/UDLaPalmas.png");
            equipos[17] = CrearEquipo("UD La Palmas",imagen,0,false);
            imagen.BaseUri = new Uri("pack://application:,,,/Images/Shields/VallaRealCF.png");
            equipos[18] = CrearEquipo("VallaReal CF",imagen,0,false);
            imagen.BaseUri = new Uri("pack://application:,,,/Images/Shields/Viol-EnciaCF.png");
            equipos[19] = CrearEquipo("Viol-Encia CF",imagen,0,false);
            return equipos.ToList();


            
        }
        }
}
