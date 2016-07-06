﻿using System;
using System.Collections;
using System.Collections.Generic;

namespace Collections.Enumerable
{
    public class BandsEnumerator : IEnumerator<Band>
    {
        public Band Current { get { return currentBand; } }
        object IEnumerator.Current
        {
            get { return Current; }
        }

        private Band[] collection;
        private int currentIndex;
        private Band currentBand;

        public BandsEnumerator(Band[] bandsArray)
        {
            collection = bandsArray;
            //until "MoveNext" is called first time, the enumerator is positioned before the first element
            Reset();
        }

        public void Dispose() { }

        //public bool MoveNext()
        //{
        //    currentIndex--;

        //    if (currentIndex <= collection.Length)
        //    {
        //        return false;
        //    }

        //    currentBand = collection[currentIndex];
        //    return true;
        //}

        public void Reset()
        {
            currentBand = null;
            currentIndex = collection.Length;
        }

        public bool MoveNext()
        {

            // Read from the last element to the first one. The trick is to change in the reset method the currentIndex to be the last item in the iteration;
            currentIndex--;
            if (currentIndex < 0)
            {
                return false;
            }
            currentBand = collection[currentIndex];
            return true;
        }

        //public bool MoveNext()
        //{
        //    currentIndex++;
        //    if (currentIndex >= collection.Length)
        //    {
        //        return false;
        //    }

        //    currentBand = collection[currentIndex];
        //    return true;
        //}


        //public void Reset()
        //{
        //    currentIndex = -1;
        //    currentBand = null;
        //}

    }
}
