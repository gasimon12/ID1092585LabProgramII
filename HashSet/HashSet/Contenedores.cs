using System;
using System.Collections.Generic;
using System.Text;

namespace HashSet
{
    public class Contenedores : HashSet<User>
    {
        public static LinkedList<User>[] Segment =
        {
            new LinkedList<User>(),
            new LinkedList<User>(),
            new LinkedList<User>(),
            new LinkedList<User>(),
            new LinkedList<User>(),
            new LinkedList<User>(),
            new LinkedList<User>(),
            new LinkedList<User>(),
        };
        public new bool Add(User user)
        {
            if (Contains(user))
            {
                return false; 
            }
            var List = Segment[user.GetHashCode() % 8];
            List.AddFirst(user);
            return true;
        }
        public new bool Contains(User user)
        {
            var List = Segment[user.GetHashCode() % 8];
            foreach (var element in List)
            {
                if (element.Equals(user))
                {
                    return true;
                }
            }
            return false;
        }
        public new bool Remove(User user)
        {
            if (Contains(user))
            {
                int vcode = user.GetHashCode() % 8;
                foreach (var element in Segment[vcode])
                {
                    if (element.Equals(user))
                    {
                        Segment[vcode].Remove(element);
                        return true;
                    }
                }
            }
            return false;
        }
    }
}
