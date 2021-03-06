﻿using System;
using System.Collections.Generic;
using Iota.Lib.CSharp.Api;
using Iota.Lib.CSharp.Api.Exception;
using Iota.Lib.CSharp.Api.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Iota.Lib.CSharpTests.Api
{
    [TestClass]
    public class IotaApiTests
    {
        private static readonly string TEST_SEED1 =
            "IHDEENZYITYVYSPKAURUZAQKGVJEREFDJMYTANNXXGPZ9GJWTEOJJ9IPMXOGZNQLSNMFDSQOTZAEETUEA";

        private static readonly string TEST_ADDRESS_WITH_CHECKSUM_SECURITY_LEVEL_1 =
            "MALAZGDVZIAQQRTNYJDSZMY9VE9LAHQKTVCUOAGZUCX9IBUMODFFTMGUIUAXGLWZQ9CYRSLYBM9QBIBYAEIAOPKXEA";

        private static readonly string TEST_ADDRESS_WITH_CHECKSUM_SECURITY_LEVEL_2 =
            "LXQHWNY9CQOHPNMKFJFIJHGEPAENAOVFRDIBF99PPHDTWJDCGHLYETXT9NPUVSNKT9XDTDYNJKJCPQMZCCOZVXMTXC";

        private static readonly string TEST_ADDRESS_WITH_CHECKSUM_SECURITY_LEVEL_3 =
            "ASCZZOBQDMNHLELQKWJBMRETMHBTF9V9TNKYDIFW9PDXPUHPVVGHMSWPVMNJHSJF99QFCMNTPCPGS9DT9XAFKJVO9X";

        private static readonly string TEST_ADDRESS_WITHOUT_CHECKSUM_SECURITY_LEVEL_1 =
            "MALAZGDVZIAQQRTNYJDSZMY9VE9LAHQKTVCUOAGZUCX9IBUMODFFTMGUIUAXGLWZQ9CYRSLYBM9QBIBYA";

        private static readonly string TEST_ADDRESS_WITHOUT_CHECKSUM_SECURITY_LEVEL_2 =
            "LXQHWNY9CQOHPNMKFJFIJHGEPAENAOVFRDIBF99PPHDTWJDCGHLYETXT9NPUVSNKT9XDTDYNJKJCPQMZC";

        private static readonly string TEST_ADDRESS_WITHOUT_CHECKSUM_SECURITY_LEVEL_3 =
            "ASCZZOBQDMNHLELQKWJBMRETMHBTF9V9TNKYDIFW9PDXPUHPVVGHMSWPVMNJHSJF99QFCMNTPCPGS9DT9";

        private static readonly string TEST_SEED2 =
            "IHDEENZYITYVYSPKAURUZAQKGVJEREFDJMYTANNXXGPZ9GJWTEOJJ9IPMXOGZNQLSNMFDSQOTZAEETUEA";

        private static readonly string TEST_HASH =
            "9XWWWXVQYPKLVMAMFPXFSE9UCAGVY9RZO9NHGAZEXIRIJRZULGMFOJNDKUNFUCSURWRDDPVMYG9X99999"; //06/02/2018,04:36

        private static readonly string TEST_TRYTES =
            "999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999LXQHWNY9CQOHPNMKFJFIJHGEPAENAOVFRDIBF99PPHDTWJDCGHLYETXT9NPUVSNKT9XDTDYNJKJCPQMZCQ9CA9TA99999999999999999999XC9999999999999999999999999TPLCUYD99999999999B99999999WFVTNIRLVFIVKAQEEDFRWWLXIPHRQNG9EAY9QEWRFDLECXDGJLIKBAKBYPTAZPISWVXJLBJISGGLWTBVDNBEBXBG9PZHPK9SVNH99LZVXYZSVODZZIIXNJJQAYXCNKISVFVXGVQMURVEMSDGLRLZADQCOHRHW99999K9SYJTSNRZVYWGSV9AXVTPKMTLHPCTIJGNNAMALVPQUCGCZXZFFUQSXCHPSJLXBADVOIZO9PSZYTA9999XC9999999999999999999999999WWF9MWCJE999999999MMMMMMMMMPRQAGSHN9ZHEWVAANNPXSDRRROY";

        private static readonly string TEST_MESSAGE = "COTA";
        private static readonly string TEST_TAG = "COTASPAM9999999999999999999";

        // ReSharper disable once InconsistentNaming
        private static readonly string[] TEST_ADDRESSES =
        {
            "LXQHWNY9CQOHPNMKFJFIJHGEPAENAOVFRDIBF99PPHDTWJDCGHLYETXT9NPUVSNKT9XDTDYNJKJCPQMZCCOZVXMTXC",
            "P9UDUZMN9DEXCRQEKLJYSBSBZFCHOBPJSDKMLCCVJDOVOFDWMNBZRIRRZJGINOUMPJBMYYZEGRTIDUABD",
            "MIMVJEYREIIZLXOXQROMPJFCIX9NFVXD9ZQMNZERPI9OJIJFUWQ9WCTMKXEEPHYPWEZPHLJBJOFH9YTRB",
            "FOJHXRVJRFMJTFDUWJYYZXCZIJXKQALLXMLKHZFDMHWTIBBXUKSNSUYJLKYRQBNXKRSUXZHDTPWXYD9YF",
            "B9YNPQO9EXID9RDEEGLCBJBYKBLWHTOQOZKTLJDFPJZOPKJJTNUYUVVTDJPBCBYIWGPSCMNRZFGFHFSXH",
            "NQEFOAFIYKZOUXDFQ9X9PHCNSDETRTJZINZ9EYGKU99QJLDSTSC9VTBAA9FHLNLNYQXWLTNPRJDWCGIPP",
            "CEGLBSXDJVXGKGOUHRGMAQDRVYXCQLXBKUDWKFFSIABCUYRATFPTEEDIFYGAASKFZYREHLBIXBTKP9KLC",
            "QLOXU9GIQXPPE9UUT9DSIDSIESRIXMTGZJMKLSJTNBCRELAVLWVJLUOLKGFCWAEPEQWZWPBV9YZJJEHUS",
            "XIRMYJSGQXMM9YPHJVVLAVGBBLEEMOOKHHBFWKEAXJFONZLNSLBCGPQEVDMMOGHFVRDSYTETIFOIVNCR9",
            "PDVVBYBXMHZKADPAYOKQNDPHRSWTHAWQ9GRVIBOIMZQTYCWEPCDWDVRSOUNASVBDLBOAMVLYEVVCMAM9N",
            "U9GAIAPUUQWJGISAZWPLHUELTZ9WSHWXS9JLPKOWHRRIVUKGWCTJMBULVMKTETTUNHZ9HWHBALUCJIROU",
            "VFPMKZLLMDUOEKNBEKQZPTNZJZF9UHRWSTHXLWQQ9OAXTZQHTZPAWNJNXKAZFSDFWKFQEKZIGJTLWQFLO",
            "IGHK9XIWOAYBZUEZHQLEXBPTXSWVANIOUZZCPNKUIJIJOJNAQCJWUJHYKCZOIKVAAHDGAWJZKLTPVQL9G",
            "LXQPWMNXSUZTEYNC9ZBBFHY9YWCCOVKBNIIOUSVXZJZMJKJFDUWGUVXYCHGKUHEEIDHSGEWFAHVJPRIJT",
            "AKFDX9PGGQLZUWRMZ9YBDF9CG9TWXCNALCSXSAWHFIMGXCSYCJLSWIQDGGVDRMNEKKECQEYAITGNLNJFQ",
            "YX9QSPYMSFVOW9UVZRDVOCPYYMUTDHCCPKHMXQSJQJYIXVCHILKW9GBYJTYGLIKBTRQMDCYBMLLNGSSIK",
            "DSYCJKNG9TAGJHSKZQ9XLKAKNSKJFZIPVEDGJFXRTFGENHZFQGXHWDBNXLLDABDMOYELPG9DIXSNJFWAR",
            "9ANNACZYLDDPZILLQBQG9YMG9XJUMTAENDFQ9HMSSEFWYOAXPJTUXBFTSAXDJPAO9FKTWBBSCSFMOUR9I",
            "WDTFFXHBHMFQQVXQLBFJFVVHVIIAVYM9PFAZCHMKET9ESMHIRHSMVDJBZTXPTAFVIASMSXRDCIYVWVQNO",
            "XCCPS9GMTSUB9DXPVKLTBDHOFX9PJMBYZQYQEXMRQDPGQPLWRGZGXODYJKGVFOHHYUJRCSXAIDGYSAWRB",
            "KVEBCGMEOPDPRCQBPIEMZTTXYBURGZVNH9PLHKPMM9D9FUKWIGLKZROGNSYIFHULLWQWXCNAW9HKKVIDC"
        };

        private static readonly string TestTrytesValid =
            "JUSTANOTHERTEST999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999999PNGMCSNRCTRHCHPXYTPKEJYPCOWKOMRXZFHH9N9VDIKMNVAZCMIYRHVJIAZARZTUETJVFDMBEBIQE9QTH999999999999999999999999999COTASPAM9999999999999999999VISYF9DGE999999999999999999FB9CRHGOHK9EIDHDUWSGDDONYQAABTRXXMFUKRZHMVJAPCAADTRDCWZJRHAPL9LRIVZFVKQV9GAWSSJZDPWGPQTPWCPNYONYGGSJLJAQYXLZ9FMOTUJT9RIXAOXFDQZSTZYBCHSNLSM9JAXTMNQBUHAAZIIR999999PWGPQTPWCPNYONYGGSJLJAQYXLZ9FMOTUJT9RIXAOXFDQZSTZYBCHSNLSM9JAXTMNQBUHAAZIIR999999KXOQZNGXOCACOVYKPWWJFQQMEWDQVUZRI99WFQEJANSOPVLZGQHLUEYKPYPMSTLDRDVEBMCQMKQLL9JFS";

        private static int MIN_WEIGHT_MAGNITUDE = 14;
        private static int DEPTH = 9;

        private IotaApi _iotaClient;

        [TestInitialize]
        public void CreateApiClientInstance()
        {
            _iotaClient = new IotaApi("node.iotawallet.info", 14265);
        }

        [TestMethod]
        public void ShouldGetInputs()
        {
            var res = _iotaClient.GetInputs(TEST_SEED1, 2, 0, 0, 0);
            Console.WriteLine(res);
            Assert.IsNotNull(res);
            Assert.IsNotNull(res.TotalBalance);
            Assert.IsNotNull(res.InputsList);
        }

        [TestMethod]
        public void ShouldCreateANewAddressWithChecksum()
        {
            // ReSharper disable RedundantArgumentDefaultValue
            var res1 = _iotaClient.GetNewAddress(TEST_SEED1, 1, 0, true, 5, false);
            Assert.AreEqual(res1[0], TEST_ADDRESS_WITH_CHECKSUM_SECURITY_LEVEL_1);

            var res2 = _iotaClient.GetNewAddress(TEST_SEED1, 2, 0, true, 5, false);
            Assert.AreEqual(res2[0], TEST_ADDRESS_WITH_CHECKSUM_SECURITY_LEVEL_2);

            var res3 = _iotaClient.GetNewAddress(TEST_SEED1, 3, 0, true, 5, false);
            Assert.AreEqual(res3[0], TEST_ADDRESS_WITH_CHECKSUM_SECURITY_LEVEL_3);
            // ReSharper restore RedundantArgumentDefaultValue
        }

        [TestMethod]
        public void ShouldCreateANewAddressWithoutChecksum()
        {
            // ReSharper disable RedundantArgumentDefaultValue
            var res1 = _iotaClient.GetNewAddress(TEST_SEED1, 1, 0, false, 5, false);
            Assert.AreEqual(res1[0], TEST_ADDRESS_WITHOUT_CHECKSUM_SECURITY_LEVEL_1);

            var res2 = _iotaClient.GetNewAddress(TEST_SEED1, 2, 0, false, 5, false);
            Assert.AreEqual(res2[0], TEST_ADDRESS_WITHOUT_CHECKSUM_SECURITY_LEVEL_2);

            var res3 = _iotaClient.GetNewAddress(TEST_SEED1, 3, 0, false, 5, false);
            Assert.AreEqual(res3[0], TEST_ADDRESS_WITHOUT_CHECKSUM_SECURITY_LEVEL_3);
            // ReSharper restore RedundantArgumentDefaultValue
        }

        [TestMethod]
        public void ShouldCreate100Addresses()
        {
            // ReSharper disable RedundantArgumentDefaultValue
            var res = _iotaClient.GetNewAddress(TEST_SEED1, 2, 0, false, 100, false);
            Assert.AreEqual(res.Length, 100);
            // ReSharper restore RedundantArgumentDefaultValue
        }

        [TestMethod]
        [ExpectedException(typeof(NotEnoughBalanceException))]
        public void ShouldPrepareTransfer()
        {
            var transfers = new List<Transfer>
            {
                new Transfer(TEST_ADDRESS_WITH_CHECKSUM_SECURITY_LEVEL_2, 100, TEST_MESSAGE, TEST_TAG),
            };

            var trytes = _iotaClient.PrepareTransfers(TEST_SEED1, 2, transfers.ToArray(), null, null, false);

            Assert.IsNotNull(trytes);
            Assert.IsFalse(trytes.Count == 0);

        }

        //seed contains 0 balance
        [TestMethod]
        [ExpectedException(typeof(NotEnoughBalanceException))]
        public void ShouldPrepareTransferWithInputs()
        {
            List<Input> inputlist = new List<Input>();
            List<Transfer> transfers = new List<Transfer>();

            var inputs = _iotaClient.GetInputs(TEST_SEED1, 2, 0, 0, 0);

            inputlist.AddRange(inputs.InputsList);

            transfers.Add(new Transfer(TEST_ADDRESS_WITH_CHECKSUM_SECURITY_LEVEL_2, 100, TEST_MESSAGE, TEST_TAG));
            List<string> trytes =
                _iotaClient.PrepareTransfers(TEST_SEED1, 2, transfers.ToArray(), null, inputlist, true);

            Assert.IsNotNull(trytes);
            Assert.IsFalse(trytes.Count == 0);
        }


        [TestMethod]
        public void ShouldGetLastInclusionState()
        {
            var res = _iotaClient.GetLatestInclusion(new[] {TEST_HASH});
            Assert.IsNotNull(res.States);
        }

        [TestMethod]
        public void ShouldFindTransactionObjects()
        {
            var ftr = _iotaClient.FindTransactionObjects(TEST_ADDRESSES);
            Assert.IsNotNull(ftr);
        }

        [TestMethod]
        public void ShouldGetAccountData()
        {
            var accountData = _iotaClient.GetAccountData(TEST_SEED1, 2, 0, true, 0, true, 0, 0, true, 0);
            Assert.IsNotNull(accountData);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ShouldNotGetBundle()
        {
            var bundle = _iotaClient.GetBundle("SADASD");
            Assert.IsNotNull(bundle);
        }

        [TestMethod]
        public void ShouldGetBundle()
        {
            var bundle = _iotaClient.GetBundle(TEST_HASH);
            Assert.IsNotNull(bundle);
        }

        [TestMethod]
        public void ShouldGetTransfers()
        {
            // ReSharper disable RedundantArgumentDefaultValue
            var gtr = _iotaClient.GetTransfers(TEST_SEED1, 2, 0, 0, false);
            // ReSharper restore RedundantArgumentDefaultValue

            foreach (var b in gtr) Assert.IsTrue(b.Transactions.TrueForAll(t => t != null));
        }

        [Ignore]
        [TestMethod]
        public void ShouldReplayBundle()
        {
            var replayedList = _iotaClient.ReplayBundle(TEST_HASH, DEPTH, MIN_WEIGHT_MAGNITUDE);
            Assert.IsNotNull(replayedList);
        }

        [Ignore]
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ShouldNotSendTrytes()
        {
            _iotaClient.SendTrytes(new[] {TEST_TRYTES}, 9);
        }

        [TestMethod]
        public void ShouldGetTrytes()
        {
            _iotaClient.GetTrytes(TEST_HASH);
        }

        [TestMethod]
        public void ShouldBroadcastAndStore()
        {
            _iotaClient.BroadcastAndStore(new List<string> {TEST_TRYTES});
        }

        [Ignore]
        [TestMethod]
        public void ShouldSendTrytes()
        {
            _iotaClient.SendTrytes(new[] {TestTrytesValid}, 9);
        }

        [Ignore]
        [TestMethod]
        [ExpectedException(typeof(IllegalStateException))]
        public void ShouldNotSendTransfer()
        {
            Transfer[] transfers =
            {
                new Transfer(TEST_ADDRESS_WITHOUT_CHECKSUM_SECURITY_LEVEL_2, 2, TEST_MESSAGE, TEST_TAG)
            };

            var result = _iotaClient.SendTransfer(TEST_SEED1, 2, DEPTH, MIN_WEIGHT_MAGNITUDE, transfers, null, null,
                false, true);
            Assert.IsNotNull(result);
        }

        [Ignore]
        [TestMethod]
        public void ShouldSendTransferWithoutInputs()
        {
            var transfers = new List<Transfer>
            {
                new Transfer(TEST_ADDRESS_WITHOUT_CHECKSUM_SECURITY_LEVEL_2, 1, "JUSTANOTHERTEST", TEST_TAG)
            };

            var str = _iotaClient.SendTransfer(TEST_SEED2, 2, 9, 14, transfers.ToArray(), null, null, false, true);

            Assert.IsNotNull(str);
        }

        [Ignore]
        [TestMethod]
        public void ShouldSendTransferWithInputs()
        {
            List<Input> inputlist = new List<Input>();
            List<Transfer> transfers = new List<Transfer>();

            var inputs = _iotaClient.GetInputs(TEST_SEED1, 2, 0, 0, 1);

            inputlist.AddRange(inputs.InputsList);

            transfers.Add(new Transfer(TEST_ADDRESS_WITHOUT_CHECKSUM_SECURITY_LEVEL_2, 1, TEST_MESSAGE, TEST_TAG));

            var str = _iotaClient.SendTransfer(TEST_SEED1, 2, DEPTH, MIN_WEIGHT_MAGNITUDE, transfers.ToArray(),
                inputlist.ToArray(), null,
                true, true);

            Assert.IsNotNull(str);
        }
    }
}