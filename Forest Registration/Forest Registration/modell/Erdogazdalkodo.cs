﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forest_Register.modell
{
    /// <summary>
    /// Erdőgazdálkodó osztály
    /// </summary>
    partial class Erdogazdalkodo
    {
        private string egKod;
        private string erdogazNev;
        private string erdogazCim;

        /// <summary>
        /// Konstruktor
        /// </summary>
        /// <param name="egKod"></param>
        /// <param name="erdogazNev"></param>
        /// <param name="erdogazCim"></param>
        public Erdogazdalkodo(string egKod, string erdogazNev, string erdogazCim)
        {
            this.egKod = egKod;
            this.erdogazNev = erdogazNev;
            if (!nevEllenorzes(erdogazNev))
            {
                throw new HibasErGazNevException("A név nem megfelelő");
            }
            if (!CimHelyes(erdogazCim))
            {
                throw new HibasErGazCimException("A cím nem megfelelő");
            }
            
            this.erdogazCim = erdogazCim;
        }

        //Ellenőrzi a nevet hogy helyes-e
        public bool nevEllenorzes(string erdogazNev)
        {
            if (erdogazNev == string.Empty)
            {
                return false;
            }

            if (!char.IsUpper(erdogazNev.ElementAt(0)))
            {
                return false;
            }

            for (int i = 1; i < erdogazNev.Length; i++)
            {
                if ((!char.IsLetter(erdogazNev.ElementAt(i))) && (!char.IsWhiteSpace(erdogazNev.ElementAt(i))))
                {
                    return false;
                }
            }
            return true;
        }

        private bool CimHelyes(string erdogazCim)
        {
            if (erdogazCim == string.Empty)
                return false;
            if (!char.IsUpper(erdogazCim.ElementAt(0)))
                return false;
            for (int i = 1; i < erdogazCim.Length; i++)
                if ((!char.IsLetter(erdogazCim[i])) && (!char.IsWhiteSpace(erdogazNev.ElementAt(i))))
                    return false;
            return true;
        }

        /// <summary>
        /// kod, nev, cim adatoknak értékadás
        /// </summary>
        /// <param name="egKod"></param>
        public void setKod(string egKod)
        {
            this.egKod = egKod;
        }

        /// <param name="erdogazNev"></param>
        public void setErdogazNev(string erdogazNev)
        {
            this.erdogazNev = erdogazNev;
        }

        /// <param name="erdogazCim"></param>
        public void setErdogazCim(string erdogazCim)
        {
            this.erdogazCim = erdogazCim;
        }

        /// <summary>
        /// kod, nev, cim adatok lekérdezése
        /// </summary>
        /// <returns>kod, nev, cim</returns>
        public string getKod()
        {
            return egKod;
        }

        public string getErdogazNev()
        {
            return erdogazNev;
        }

        public string getErdogazCim()
        {
            return erdogazCim;
        }

        public void modosit(Erdogazdalkodo modify)
        {
            this.egKod = modify.getKod();
            this.erdogazNev = modify.getErdogazNev();
            this.erdogazCim = modify.getErdogazCim();
        }
    }
}
