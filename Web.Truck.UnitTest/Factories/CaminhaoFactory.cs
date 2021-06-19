using System;
using System.Collections.Generic;
using Web.Truck.Domain.DTOs.Caminhao;
using Web.Truck.Domain.Entities;

namespace Web.Truck.UnitTest.Factories
{
    public class CaminhaoFactory
    {
        public static IEnumerable<object[]> GetCaminhoesValidos()
        {
            yield return new object[] { new Caminhao("PWORKRIFPW", DateTime.Now.Year, DateTime.Now.Year, 1) };
            yield return new object[] { new Caminhao("LKIIOOEWMZ", DateTime.Now.Year, DateTime.Now.Year + 1, 1) };
            yield return new object[] { new Caminhao("PWORKRIFPW", DateTime.Now.Year, DateTime.Now.Year, 2) };
        }

        public static IEnumerable<object[]> GetCaminhoesInvalidos()
        {
            yield return new object[] { new Caminhao("DEDKWDNWL3W", DateTime.Now.Year - 1, DateTime.Now.Year, 4) };
            yield return new object[] { new Caminhao("WEPZGEDH87", DateTime.Now.Year + 5, DateTime.Now.Year, 1) };
            yield return new object[] { new Caminhao("DWDWKNDDQ2", DateTime.Now.Year, DateTime.Now.Year - 1, 1) };
            yield return new object[] { new Caminhao("DFWKMQW028KNMWDDWWSFD", DateTime.Now.Year + 2, DateTime.Now.Year - 8, 3) };
        }

        public static IEnumerable<object[]> GetCaminhoesDTOValidos()
        {
            yield return new object[] { new CaminhaoDTO() { 
                AnoFabricacao = DateTime.Now.Year, 
                AnoModelo = DateTime.Now.Year+1, 
                Chassi = "IUYTRFERD", 
                Modelo = "FM" } 
            };
            yield return new object[] { new CaminhaoDTO { 
                AnoFabricacao = DateTime.Now.Year, 
                AnoModelo = DateTime.Now.Year, 
                Chassi = "EFJNEÇLKJ445WD", 
                Modelo = "FM" } 
            };
            yield return new object[] { new CaminhaoDTO { 
                AnoFabricacao = DateTime.Now.Year, 
                AnoModelo = DateTime.Now.Year, 
                Chassi = "JYNHTGRFD", 
                Modelo = "FH" } 
            };
        }

        public static IEnumerable<object[]> GetCaminhoesDTOInvalidos()
        {
            yield return new object[] { new CaminhaoDTO() {
                AnoFabricacao = DateTime.Now.Year-2,
                AnoModelo = DateTime.Now.Year+2,
                Chassi = "IUYTRFERD",
                Modelo = "yy" }
            };
            yield return new object[] { new CaminhaoDTO {
                AnoFabricacao = DateTime.Now.Year,
                AnoModelo = DateTime.Now.Year,
                Chassi = "EFJNEÇLKJ445WD",
                Modelo = ";)" }
            };
            yield return new object[] { new CaminhaoDTO {
                AnoFabricacao = DateTime.Now.Year,
                AnoModelo = DateTime.Now.Year+2,
                Chassi = "JYNHTGRFD",
                Modelo = "FH" }
            };
        }

        public static IEnumerable<object[]> GetCaminhaoDTOModeloInvalido()
        {
            yield return new object[] { new CaminhaoDTO() {
                AnoFabricacao = DateTime.Now.Year,
                AnoModelo = DateTime.Now.Year,
                Chassi = "IUY122152152TRFERD",
                Modelo = "TH" }
            };
        }

        public static IEnumerable<object[]> GetCaminhaoUpdateDTOModeloValido()
        {
            yield return new object[] { new CaminhaoUpdateDTO() {
                Id = 1,
                AnoFabricacao = DateTime.Now.Year,
                AnoModelo = DateTime.Now.Year+1,
                Chassi = "QWERTYUIOPSADFGHJKL",
                Modelo = "FM" }
            };
        }
    }
}
