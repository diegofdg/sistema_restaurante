﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Security.Cryptography;
using System.Management;

namespace RestCsharp.Logica
{
    public class Bases
    {
        public void DiseñoDatagridview(ref DataGridView Listado)
        {
            Listado.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            Listado.EnableHeadersVisualStyles = false;
            DataGridViewCellStyle cabecera = new DataGridViewCellStyle();
            cabecera.BackColor = Color.White;
            cabecera.ForeColor = Color.Black;
            cabecera.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            Listado.ColumnHeadersDefaultCellStyle = cabecera;
        }
        public void DiseñoDatagridviewEliminar(ref DataGridView Listado)
        {
            foreach (DataGridViewRow row in Listado.Rows)
            {
                string estado;
                estado = row.Cells["Estado"].Value.ToString();
                if (estado == "ELIMINADO")
                {
                    row.DefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Strikeout | FontStyle.Bold);
                    row.DefaultCellStyle.ForeColor = Color.Red;
                }
            }
        }
        public static TripleDESCryptoServiceProvider des = new TripleDESCryptoServiceProvider();
        public static MD5CryptoServiceProvider hashmd5 = new MD5CryptoServiceProvider();

        public static string Encriptar(string texto)
        {
            string tempEncriptar = null;
            if (string.IsNullOrEmpty(texto.Trim(' ')))
            {
                tempEncriptar = "";
            }
            else
            {
                des.Key = hashmd5.ComputeHash((new UnicodeEncoding()).GetBytes(Desencryptacion.appPwdUnique));
                des.Mode = CipherMode.ECB;
                ICryptoTransform encrypt = des.CreateEncryptor();
                byte[] buff = UnicodeEncoding.ASCII.GetBytes(texto);
                tempEncriptar = Convert.ToBase64String(encrypt.TransformFinalBlock(buff, 0, buff.Length));
            }
            return tempEncriptar;
        }
        public static string Desencriptar(string texto)
        {
            string tempDesencriptar = null;
            if (string.IsNullOrEmpty(texto.Trim(' ')))
            {
                tempDesencriptar = "";
            }
            else
            {
                des.Key = hashmd5.ComputeHash((new UnicodeEncoding()).GetBytes(Desencryptacion.appPwdUnique));
                des.Mode = CipherMode.ECB;
                ICryptoTransform desencrypta = des.CreateDecryptor();
                byte[] buff = Convert.FromBase64String(texto);
                tempDesencriptar = UnicodeEncoding.ASCII.GetString(desencrypta.TransformFinalBlock(buff, 0, buff.Length));
            }
            return tempDesencriptar;
        }
        public static void Obtener_serialPC(ref string serial)
        {
            ManagementObject serialPC = new ManagementObject("Win32_PhysicalMedia='\\\\.\\PHYSICALDRIVE0'");
            serial = serialPC.Properties["SerialNumber"].Value.ToString();
            serial = Encriptar(serial.Trim());

        }
    }
}
