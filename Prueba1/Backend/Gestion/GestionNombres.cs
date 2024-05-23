using System.IO;

namespace Prueba1.Backend.Gestion
{
    internal class GestionNombres
    {
        private List<string> nombres;
        private List<string> apellidos;
        private Random random;

        public GestionNombres() : this("Nombres.csv", "Apellidos.csv")
        {
        }



        public GestionNombres(string firstNameFilePath, string lastNameFilePath)
        {
            nombres = File.ReadAllLines(firstNameFilePath).ToList();
            apellidos = File.ReadAllLines(lastNameFilePath).ToList();
            random = new Random();
        }

        public string GenerarNombreAleatorio()
        {
            var nombre = GenerarNombre();
            var apellido = GenerarApellido();
            return $"{nombre} {apellido}";
        }

        private string GenerarNombre()
        {
            return nombres[random.Next(nombres.Count)];
        }

        private string GenerarApellido()
        {
            return apellidos[random.Next(apellidos.Count)];
        }
    }
}
