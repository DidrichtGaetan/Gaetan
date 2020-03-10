using System;
using System.Collections.Generic;
using System.Text;

namespace MyCartographyObjects

{
    public abstract class CartoObj : IIsPointClose
    {
        private int _id;
        private static int _cpt;

        #region PROPRIETE
        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }

        public int cpt
        {
            get { return _cpt; }
            set { _cpt = value; }
        }
        #endregion

        #region CONSTRUCTEURS
        public CartoObj()
        {
            _id = _cpt;
            _cpt++;
        }

        #endregion

        #region ToString()
        public override string ToString()
        {
            return "  (identifiant: " + _id + ")";
        }
        #endregion

        #region VIRTUELLE
        public virtual void Draw()
        {
            Console.Write(this.ToString());
        }

        public int IsPointClose(double latitude, double longitude, double precision)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}

