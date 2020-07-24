using System;
using System.Collections.Generic;
using System.Linq;

namespace VirtualCoach
{
    class AccObserver : IObserver<string>
    {
        private List<string> _data = new List<string>();

        public IEnumerable<double[]> XYZ 
        { 
            get 
            {
                return _data.Select(d => d.Split(',').Skip(2).Take(3).Select(double.Parse).ToArray());
            }
        }

        public IEnumerable<double> Magnitudes
        {
            get
            {
                return XYZ.Select(xyz => Math.Sqrt(xyz.Select(v => Math.Pow(v,2)).Sum()) );
            }
        }

        public void OnCompleted()
        {
            throw new NotImplementedException();
        }

        public void OnError(Exception error)
        {
            throw new NotImplementedException();
        }

        public void OnNext(string value)
        {
            var xyz = value.Split(',').Skip(2).Take(3).Select(double.Parse);
            var mag = Math.Sqrt(xyz.Select(val => Math.Pow(val, 2)).Sum());

            if (value.Contains("E4_Acc"))
            {
                _data.Add(value);
            }
        }
    }
}
