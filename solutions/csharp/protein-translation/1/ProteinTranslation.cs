using System;
using System.Security.Cryptography;

public static class ProteinTranslation
{
    public static string[] Proteins(string strand)
    {
        int index = 0;
        List<string> codons = new List<string>();
        List<string> proteins = new List<string>();

        for (int i = 0; i < strand.Length; i += 3)
        {
            if (i + 3 <= strand.Length)
                codons.Add(strand.Substring(i, 3));
        }

        while (index < codons.Count)
        {
            string codon = codons[index];
            if (codon == "UAA" || codon == "UAG" || codon == "UGA")
                break;
            if (codon == "AUG")
                proteins.Add("Methionine");
            if (codon == "UUU" || codon == "UUC")
                proteins.Add("Phenylalanine");
            if (codon == "UUA" || codon == "UUG")
                proteins.Add("Leucine");
            if (codon == "UCU" || codon == "UCC" || codon == "UCA" || codon == "UCG")
                proteins.Add("Serine");
            if (codon == "UAU" || codon == "UAC")
                proteins.Add("Tyrosine");
            if (codon == "UGU" || codon == "UGC")
                proteins.Add("Cysteine");
            if (codon == "UGG")
                proteins.Add("Tryptophan");
            index++;
        }
        return proteins.ToArray();
    }
}