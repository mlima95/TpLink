using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GesperForms
{
    delegate void RequeteLinq();
    public partial class FormRequete : Form
    {
        private ModelGesper bd;
        private List<RequeteLinq> lesRequetes;
        

        public FormRequete()
        {
            InitializeComponent();
            bd = new ModelGesper();
            lesRequetes = new List<RequeteLinq>();
            listerRequetes();
        }

        private void listerRequetes()
        {
            cbRequete.Items.Add("requete 0 : nom des employés");
            lesRequetes.Add(requete0);
            cbRequete.Items.Add("requete 1 : nom et prénom des employés");
            lesRequetes.Add(requete1);
            cbRequete.Items.Add("Requête 2 : service des employés");
            lesRequetes.Add(requete2);
            cbRequete.Items.Add("Requête 3 : nom des employés et désignation de leur service");
            lesRequetes.Add(requete3);
            cbRequete.Items.Add("Requête 4 : nom des employés et désignation de leur service avec un type anonyme");
            lesRequetes.Add(requete4);
            cbRequete.Items.Add("Requête 5 : nom et prénom des employés masculins");
            lesRequetes.Add(requete5);
            cbRequete.Items.Add("Requête 6 : nom et prénom des employés masculins gagnant plus de 3000€");
            lesRequetes.Add(requete6);
            cbRequete.Items.Add("Requête 7 : nom et prénom des employés du service commercial");
            lesRequetes.Add(requete7);
            cbRequete.Items.Add("Requête 8 : nom et prénom des employés cadres");
            lesRequetes.Add(requete8);
            cbRequete.Items.Add("Requête 9 : nom et prénom des employés dont le nom contient 'du'  (contains)");
            lesRequetes.Add(requete9);
        }

        private void requete0()
        {
            var req =
            from emp in bd.employes
            select emp.emp_nom;
            foreach (string s in req)
            {

                tbResultat.AppendText(s);
                tbResultat.AppendText(Environment.NewLine);
            }
        }
            private void requete1()
            {
            var req =
                from emp in bd.employes
                select emp;
            foreach (employe e in req) {
                tbResultat.AppendText(e.emp_nom + " " + e.emp_prenom);
                tbResultat.AppendText(Environment.NewLine);
            }
        }

        private void requete2()
        {
            var req = from ser in bd.services
                      select ser;
            foreach (service s in req)
            {
                tbResultat.AppendText(s.ser_designation + " " + s.ser_type);
                tbResultat.AppendText(Environment.NewLine);
            }
        }

        private void requete3()
        {
           var req= from emp in bd.employes
            join ser in bd.services on emp.emp_service equals ser.ser_id
            select new { emp.emp_nom,ser.ser_designation };
            foreach (var v in req)
            {
                tbResultat.AppendText(v.emp_nom + " " + v.ser_designation);
                tbResultat.AppendText(Environment.NewLine);
            }
        }

        private void requete4()
        {
            var req = from emp in bd.employes
                      join ser in bd.services on emp.emp_service equals ser.ser_id
                      select new { emp.emp_nom, ser.ser_designation, ser.ser_type };
            foreach (var v in req)
            {
                tbResultat.AppendText(v.emp_nom + " " + v.ser_designation + " " + v.ser_type);
                tbResultat.AppendText(Environment.NewLine);
            }
        }

        private void requete5()
        {
            var req = from emp in bd.employes
                      where emp.emp_sexe == "M"
                      select new {emp.emp_nom,emp.emp_prenom };
            foreach(var v in req)
            {
                tbResultat.AppendText(v.emp_nom + " " + v.emp_prenom);
                tbResultat.AppendText(Environment.NewLine);
            }
        }

        private void requete6()
        {
            var req = from emp in bd.employes
                      where emp.emp_sexe == "M" && emp.emp_salaire > 3000
                      select new { emp.emp_nom, emp.emp_prenom };
            foreach (var v in req)
            {
                tbResultat.AppendText(v.emp_nom + " " + v.emp_prenom);
                tbResultat.AppendText(Environment.NewLine);
            }
        }

        private void requete7()
        {
            var req = from emp in bd.employes
                      join ser in bd.services on emp.emp_service equals ser.ser_id
                      where ser.ser_designation == "Commercial"
                      select new { emp.emp_nom, emp.emp_prenom };
            foreach (var v in req)
            {
                tbResultat.AppendText(v.emp_nom + " " + v.emp_prenom);
                tbResultat.AppendText(Environment.NewLine);
            }
        }

        private void requete8()
        {
            var req = from emp in bd.employes
                      where emp.emp_cadre==true
                      select new { emp.emp_nom, emp.emp_prenom };
            foreach (var v in req)
            {
                tbResultat.AppendText(v.emp_nom + " " + v.emp_prenom);
                tbResultat.AppendText(Environment.NewLine);
            }
        }

        private void requete9()
        {
            var req = from emp in bd.employes
                      where emp.emp_nom.Contains("du")
                      select new { emp.emp_nom, emp.emp_prenom };
            foreach (var v in req)
            {
                tbResultat.AppendText(v.emp_nom + " " + v.emp_prenom);
                tbResultat.AppendText(Environment.NewLine);
            }
        }

        private void btnOk_Click(object sender, EventArgs e)
            {
                if (cbRequete.SelectedIndex != -1)
                    tbResultat.Clear();
                lesRequetes[cbRequete.SelectedIndex]();
            }
        }
    }

