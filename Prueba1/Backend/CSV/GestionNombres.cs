using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Prueba1.Backend.CSV
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
            this.nombres = File.ReadAllLines(firstNameFilePath).ToList();
            this.apellidos = File.ReadAllLines(lastNameFilePath).ToList();
            this.random = new Random();
        }

        public string GenerarNombreAleatorio()
        {
            var nombre = GenerarNombre();
            var apellido = GenerarApellido();
            return $"{nombre} {apellido}";
        }

        private string GenerarNombre()
        {
            return this.nombres[this.random.Next(this.nombres.Count)];
        }

        private string GenerarApellido()
        {
            return this.apellidos[this.random.Next(this.apellidos.Count)];
        }
    }
}
