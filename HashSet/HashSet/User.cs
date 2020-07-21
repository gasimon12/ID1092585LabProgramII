using System;
using System.Collections.Generic;
using System.Text;

namespace HashSet
{
    public class User
    {
        public string vnombre { get; }
        public string vapellido { get; }
        public string vbal { get; }
        public string vcontra { get; }
        public string vbit { get; }

        public User(string vname, string vlast, string vbalance, string vpass, string vdato)
            => (vnombre, vapellido, vbal, vcontra, vbit) = (vname, vlast, vbalance, vpass, vdato);
        public User(string vname, string vlast)
            => (vnombre, vapellido) = (vname, vlast);

        public override bool Equals(object obj)
        {
            User other = obj as User;
            if (other == null)
            {
                return false;
            }
            string vref = this.vnombre+this.vapellido;
            string vkey = other.vnombre + other.vapellido;
            return String.Equals(vref, vkey, StringComparison.OrdinalIgnoreCase);
        }
        public override int GetHashCode()
        {
            char id = vapellido[0];
            return char.ToLowerInvariant(id);
        }
    }
}
