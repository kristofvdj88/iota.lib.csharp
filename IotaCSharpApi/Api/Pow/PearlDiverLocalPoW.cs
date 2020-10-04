﻿using System;
using Iota.Lib.CSharp.Api.Core;
using Iota.Lib.CSharp.Api.Exception;
using Iota.Lib.CSharp.Api.Utils;

namespace Iota.Lib.CSharp.Api.Pow
{
    /// <summary>
    /// </summary>
    public class PearlDiverLocalPoW : ILocalPoW
    {
        private readonly PearlDiver _pearlDiver = new PearlDiver();

        /// <summary>
        /// </summary>
        /// <param name="trytes"></param>
        /// <param name="minWeightMagnitude"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public string PerformPoW(string trytes, int minWeightMagnitude)
        {
            var trits = Converter.ToTrits(trytes);

            if (!_pearlDiver.Search(trits, minWeightMagnitude, 0))
                throw new IllegalStateException("PearlDiver search failed");

            return Converter.ToTrytes(trits);
        }
    }
}