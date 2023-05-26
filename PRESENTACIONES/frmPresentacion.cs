using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Npgsql;
using CFACADESTRUC;
using CFACADECONN;

namespace PRESENTACIONES
{
    public partial class frmPresentacion : CControl
    {
        string sTitulo = "ALTA DE PRESENTACION";
        CEstructura ep;

        public frmPresentacion(CEstructura ed)
        {
            InitializeComponent();
            ep = ed;
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmPresentacion_Load(object sender, EventArgs e)
        {
            txtPresentacion.MaxLength = 50;

            HabilitarTeclaEscape = true;
            HabilitarTeclasSalir = true;

            AgregarControl(txtPresentacion, null, true, "El campo [ PRESENTACION ] no puede estar vacío, favor de verificar...", false);

            AgregarControl(btnGuardar, null, "", false);
            AgregarControl(btnSalir, null, "", false);

            fInicializa();
        }

        public void fInicializa()
        {
            fLimpiarInformacion();
            txtPresentacion.Select();
        }

        // Limpia la informacion de los campos
        public void fLimpiarInformacion()
        {
            try
            {
                fLimpiarInformacion(groupBox1);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Se presento un problema al limpiar la información: \n" + ex.Message.ToString(), sTitulo, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public static void fLimpiarInformacion(GroupBox gb)
        {
            foreach (Control c in gb.Controls)
            {
                if (c is TextBox || c is RichTextBox)
                {
                    c.Text = "";
                }
                else if (c is ComboBox)
                {
                    var tmp = c as ComboBox;
                    tmp.DataSource = null;
                    tmp.Items.Clear();
                }
                else if (c is DataGridView)
                {
                    var tmp = c as DataGridView;
                    tmp.Rows.Clear();
                    tmp.Columns.Clear();
                }
                else if (c is CheckBox)
                {
                    var tmp = c as CheckBox;
                    tmp.Checked = false;
                }
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (fGrabarInformacion())
            {
                MessageBox.Show("Información guardada correctamente.", sTitulo, MessageBoxButtons.OK, MessageBoxIcon.Information);
                fInicializa();
            }
        }

        public bool fGrabarInformacion() 
        { 
            string sPresentacion = "", sConsulta = "", sError = "";
            bool valorRegresa = false;

            try
            {
                sPresentacion = txtPresentacion.Text;
                if (!string.IsNullOrEmpty(sPresentacion))
                {
                    NpgsqlConnection conn = new NpgsqlConnection();
                    if(CConeccion.conexionPostgre(ep, ref conn, ref sError)){
                        sConsulta = String.Format("SELECT insertar_presentacion('{0}')", sPresentacion);
                        NpgsqlCommand cmd = new NpgsqlCommand(sConsulta, conn);
                        cmd.ExecuteNonQuery();
                        valorRegresa = true;
                    }

                    if( conn.State == ConnectionState.Open)
                    {
                        conn.Close();
                    }
                }else
                {
                    MessageBox.Show("El campo [ PRESENTACION ] no puede estar vacío, favor de verificar...", sTitulo, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("Se presento un problema al guardar la información: \n" + ex.Message.ToString(), sTitulo, MessageBoxButtons.OK, MessageBoxIcon.Error);
                valorRegresa = false;
            }

            return valorRegresa;
        }
    }
}
