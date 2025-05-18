using System;
using System.Collections.Generic;
using System.Text;

public class PixQrDecoder
{

    private string qrCodeRaw = string.Empty;

    private int TamanhoCampos(string input)
    {
        //Validar que é o campo correto para pegar o tamanho
        //Deve conter 2 caracteres
        if (input.Length != 2 && !int.TryParse(input, out _))
            throw new Exception("Erro na leitura das informações do QrCode");

        return int.Parse(input);
    }
    private EnumMapeamentoISO20022 PegarMapeamentoISO20022(string input)
    {
        //Validar que é o campo correto para pegar o tamanho
        //Deve conter 2 caracteres
        if (input.Length != 2 && !int.TryParse(input, out _))
            throw new Exception("Erro na leitura das informações do QrCode");

        return (EnumMapeamentoISO20022)int.Parse(input);
    }

    public void DecodificarQrCode(string input)
    {
        try
        {
            Console.WriteLine("=== QR Code Pix Decodificado ===");
            bool lendo = true;
            int index = 0;
            do
            {
                while (input.Substring(index, 1) == " ")
                {
                    index++;
                }
                //Console.WriteLine($"Index Atual: {index}");
                var mapeamento = PegarMapeamentoISO20022(input.Substring(index, 2));
                Console.WriteLine($"Mapeamento: {mapeamento} | ");
                index += 2;
                var tamanho = TamanhoCampos(input.Substring(index, 2));
                Console.WriteLine($"Tamanho do Campo: {tamanho} | ");
                index += 2;
                var valor = input.Substring(index, tamanho);
                Console.WriteLine($"Valor lido: {valor}");
                index += tamanho;
                switch (mapeamento)
                {
                    case EnumMapeamentoISO20022.ContaComerciantePix:
                    case EnumMapeamentoISO20022.ContaComercianteOutros:
                        DecodificarContaComerciante(valor);
                        break;
                    case EnumMapeamentoISO20022.CamposAdicionais:
                        //caso o mapeamento mostre isso deve ser composto aqui dentro
                        DecodificarCamposAdicionais(valor);
                        break;
                    case EnumMapeamentoISO20022.Url:
                        //caso o mapeamento mostre isso deve ser composto aqui dentro
                        DecodificarUrl(valor);
                        break;
                    case EnumMapeamentoISO20022.CRC16:
                        break;
                }


                lendo = !(input.Length == index);
            } while (lendo);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Erro: {ex.Message}");
        }
    }

    private void DecodificarContaComerciante(string input)
    {
        Console.WriteLine("=== Decodificado Conta Comerciante ===");
        bool lendo;
        int index = 0;
        do
        {
            var mapeamento = (EnumContaComerciante)int.Parse(input.Substring(index, 2));
            Console.Write($"Mapeamento: {mapeamento} | ");
            index += 2;
            var tamanho = TamanhoCampos(input.Substring(index, 2));
            Console.Write($"Tamanho do Campo: {tamanho} | ");
            index += 2;
            var valor = input.Substring(index, tamanho);
            Console.WriteLine($"Valor lido: {valor}");
            index += tamanho;
            lendo = !(input.Length == index);
        } while (lendo);
    }

    private void DecodificarCamposAdicionais(string input)
    {
        Console.WriteLine("=== Decodificado Campos Adicionais ===");
        bool lendo;
        int index = 0;
        do
        {
            var mapeamento = (EnumCamposAdicionais)int.Parse(input.Substring(index, 2));
            Console.Write($"Mapeamento: {mapeamento} | ");
            index += 2;
            var tamanho = TamanhoCampos(input.Substring(index, 2));
            Console.Write($"Tamanho do Campo: {tamanho} | ");
            index += 2;
            var valor = input.Substring(index, tamanho);
            Console.WriteLine($"Valor lido: {valor}");
            index += tamanho;
            lendo = !(input.Length == index);
        } while (lendo);
    }

    private void DecodificarUrl(string input)
    {
        Console.WriteLine("=== Decodificado Url ===");
        bool lendo;
        int index = 0;
        do
        {
            var mapeamento = (EnumUrl)int.Parse(input.Substring(index, 2));
            Console.Write($"Mapeamento: {mapeamento} | ");
            index += 2;
            var tamanho = TamanhoCampos(input.Substring(index, 2));
            Console.Write($"Tamanho do Campo: {tamanho} | ");
            index += 2;
            var valor = input.Substring(index, tamanho);
            Console.WriteLine($"Valor lido: {valor}");
            index += tamanho;
            lendo = !(input.Length == index);
        } while (lendo);
    }



    public static ushort CalculateCRC16(string input)
    {
        byte[] bytes = Encoding.ASCII.GetBytes(input);
        ushort crc = 0xFFFF;

        foreach (var b in bytes)
        {
            crc ^= (ushort)(b << 8);
            for (int i = 0; i < 8; i++)
            {
                if ((crc & 0x8000) != 0)
                    crc = (ushort)((crc << 1) ^ 0x1021);
                else
                    crc <<= 1;
            }
        }

        return crc;
    }

    public static string Crc16CcittFalse(string input)
    {
        ushort crc = 0xFFFF;
        foreach (byte b in System.Text.Encoding.ASCII.GetBytes(input))
        {
            crc ^= (ushort)(b << 8);
            for (int i = 0; i < 8; i++)
                crc = (crc & 0x8000) != 0 ? (ushort)((crc << 1) ^ 0x1021) : (ushort)(crc << 1);
        }
        return crc.ToString("X4");
    }
}