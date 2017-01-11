using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MindboxEx1
{
    public class SequenceBuilder
    {
        public static IEnumerable<Pair<T>> Build<T>(IEnumerable<Pair<T>> collection) where T : IEquatable<T>
        {
            if (collection == null || collection.Count() == 0)
            {
                return Enumerable.Empty<Pair<T>>();
            }

            var toAdd = collection.ToList();
            var result = new List<Pair<T>>(toAdd.Count);

            Pair<T> firstElement = InitFirstElement(toAdd, result);
            T firstInSequrnce = firstElement.First;
            T lastInSequence = firstElement.Second;

            while (toAdd.Count > 0)
            {
                bool countToAddDecreased = false;
                for (int i = 0; i < toAdd.Count; i++)
                {
                    bool success = TryAddToSequence(toAdd, result, firstInSequrnce, lastInSequence, toAdd[i]);
                    if (success)
                    {
                        i--;
                        countToAddDecreased = true;
                    }
                }
                if(countToAddDecreased == false)
                {
                    throw new ArgumentException("Can't build sequence, collection has circles or unreachable item(s).", nameof(collection));
                }
            }

            return result;
        }

        private static Pair<T> InitFirstElement<T>(List<Pair<T>> toAdd, List<Pair<T>> result) where T : IEquatable<T>
        {
            var firstElement = toAdd.FirstOrDefault();
            result.Add(firstElement);
            toAdd.Remove(firstElement);
            return firstElement;
        }

        private static bool TryAddToSequence<T>(List<Pair<T>> toAdd, List<Pair<T>> result, T firstInSequrnce, T lastInSequence, Pair<T> item) where T : IEquatable<T>
        {
            if (item.First.Equals(lastInSequence))
            {
                result.Add(item);
                toAdd.Remove(item);
                return true;
            }
            else if (item.Second.Equals(firstInSequrnce))
            {
                result.Insert(0, item);
                toAdd.Remove(item);
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
