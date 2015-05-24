using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using Anarchy;
using Xunit.Abstractions;

namespace Anarchy.Facts {
  public class RawCopyFacts {

    private readonly ITestOutputHelper output;

    public RawCopyFacts(ITestOutputHelper output) {
      this.output = output;
    }
    
    private void displayResult<T>(string binary, T value, byte[] dest) {
      output.WriteLine("From: {0} ({1})", binary, value);
      for (int i = 0; i < dest.Length; i++) {
        output.WriteLine("Dest: [{0}] = {1} ({2})",
          i,
          System.Convert.ToString(dest[i], toBase: 2).PadLeft(8, '0'),
          dest[i]);
      }
    }


    [Fact]
    public void FromShortToTwoBytes() {
      string binary = "00001011" + "00001101";
      short value = System.Convert.ToInt16(binary, fromBase: 2);
      byte[] dest = new byte[2];

      Convert.RawCopyTo(ref value, ref dest[0], 2);

      Assert.Equal("1101", System.Convert.ToString(dest[0], toBase:2));
      Assert.Equal("1011", System.Convert.ToString(dest[1], toBase:2));

      displayResult(binary, value, dest);
    }


    [Fact]
    public void FromInt32ToFourBytes() {
      string binary = "00001011" + "00001101" + "11001100" + "10101100";
      int value = System.Convert.ToInt32(binary, fromBase: 2);
      byte[] dest = new byte[4];

      Convert.RawCopyTo(ref value, ref dest[0], 4);

      Assert.Equal("10101100", System.Convert.ToString(dest[0], toBase: 2));
      Assert.Equal("11001100", System.Convert.ToString(dest[1], toBase: 2));
      Assert.Equal("1101", System.Convert.ToString(dest[2], toBase: 2));
      Assert.Equal("1011", System.Convert.ToString(dest[3], toBase: 2));

      displayResult(binary, value, dest);
    }

    [Fact]
    public void FromByteToInt32() {
      byte source = System.Convert.ToByte("11001100", fromBase: 2);
      string binary = "00000000" + "00000000" + "00000000" + "00000000";
      int dest = System.Convert.ToInt32(binary, fromBase: 2);

      Convert.RawCopyTo(ref source, ref dest, 1);

      Assert.Equal("000000000000000000000000" + "11001100", 
                   System.Convert.ToString(dest, toBase: 2).PadLeft(32, '0')); 
    }

    [Fact]
    public void FromShortToInt32() {
      short source = System.Convert.ToInt16("11001100" + "10101100", fromBase: 2);
      string binary = "00000000" + "00000000" + "00000000" + "00000000";
      int dest = System.Convert.ToInt32(binary, fromBase: 2);

      Convert.RawCopyTo(ref source, ref dest, 2);

      Assert.Equal("0000000000000000" + "11001100" + "10101100",
                   System.Convert.ToString(dest, toBase: 2).PadLeft(32, '0'));
    }

    [Fact]
    public void FromInt32ToInt32() {
      int source = System.Convert.ToInt32("00000001" + "00000010" + "00000011" + "00000100", fromBase: 2);
      string binary = "00000000" + "00000000" + "00000000" + "00000000";
      int dest = System.Convert.ToInt32(binary, fromBase: 2);

      Convert.RawCopyTo(ref source, ref dest, 4);

      Assert.Equal("00000001" + "00000010" + "00000011" + "00000100",
                   System.Convert.ToString(dest, toBase: 2).PadLeft(32, '0'));
    }

    [Fact]
    public void FromInt32ToInt16() {
      int source = System.Convert.ToInt32("00000001" + "00000010" + "00000011" + "00000100", fromBase: 2);
      string binary = "00000000" + "00000000";
      short dest = System.Convert.ToInt16(binary, fromBase: 2);

      Convert.RawCopyTo(ref source, ref dest, 4);

      Assert.Equal("00000011" + "00000100",
                   System.Convert.ToString(dest, toBase: 2).PadLeft(16, '0'));
    }


    [Fact]
    public void FromInt32ToInt16_2Bytes() {
      int source = System.Convert.ToInt32("00000001" + "00000010" + "00000011" + "00000100", fromBase: 2);
      string binary = "00000000" + "00000000";
      short dest = System.Convert.ToInt16(binary, fromBase: 2);

      Convert.RawCopyTo(ref source, ref dest, 2);

      Assert.Equal("00000011" + "00000100",
                   System.Convert.ToString(dest, toBase: 2).PadLeft(16, '0'));
    }

  }
}
