﻿using DataAccesLayer.Converters;
using DataAccesLayer.Interfaces;
using Share.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccesLayer.Implementations
{
    public class DAL_Global : IDAL_Global
    {
        public ICollection<Parada> obtenerParadasDeLinea(int idLinea)
        {
            using (uruguay_busEntities db = new uruguay_busEntities())
            {
                try
                {
                    ICollection<parada> ret = new List<parada>();
                    IDictionary<int, parada> dicParada = new SortedDictionary<int,parada>();

                    linea l = db.linea.Find(idLinea);

                    foreach (var item in l.tramo)
                    {
                        dicParada.Add(item.numero,item.parada);
                    }

                    ret = dicParada.Values;

                    return ParadaConverter.convert(ret);
                }
                catch (Exception e)
                {
                    throw e;
                }
            }
        }
    }
}
