class Program
{
    static void Main()
    {
        //string qrCode = "00020126360014BR.GOV.BCB.PIX0114+5511999999995204000053039865406100.005802BR5925JOAO DA SILVA6009SAO PAULO62140510ABC123XYZ96304E9C1";
        //string qrCode = "00020104141234567890123426580014BR.GOV.BCB.PIX0136123e4567-e12b-12d1-a456 42665544000027300012BR.COM.OUTRO011001234567895204000053039865406123.45 5802BR5917NOME DO RECEBEDOR6008BRASILIA61087007490062190515RP12345678 201980390012BR.COM.OUTRO01190123.ABCD.3456.WXYZ6304AD38";
        var decoder = new PixQrDecoder();
        try
        {
            while (true)
            {
                Console.WriteLine("Informe o QR Code: ");
                string qrCode = Console.ReadLine()!;
                if (qrCode != null)
                {
                    decoder.DecodificarQrCode(qrCode);
                }
            }

        }
        catch (Exception ex)
        {
            Console.WriteLine($"Erro ao decodificar: {ex.Message}");
        }
    }
}