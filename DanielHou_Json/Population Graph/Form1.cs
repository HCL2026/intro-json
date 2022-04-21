using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DataClass;

namespace Population_Graph
{
	public partial class Graph : Form
	{
		BindingSource bs = new BindingSource();
		PData t = new PData();
		int checker;

		public Graph()
		{
			InitializeComponent();
		}

		private void Graph_Load(object sender, EventArgs e)
		{
			
		}

		private void textBox1_TextChanged(object sender, EventArgs e)
		{
			if(textBox1.Text == "China")
			{
				checker = 1;
			}
			else if(textBox1.Text == "USA")
			{
				checker = 2;
			}
			else if(textBox1.Text == "India")
			{
				checker = 3;
			}
		}

		private void button1_Click(object sender, EventArgs e)
		{
			dataGridView1.Rows.Clear();
			bs.DataSource = typeof(PopulationData);
			t.GettingData();
			if (checker == 1)
			{
				for (int i = 0; i <= 60; i++)
				{
					bs.Add(t.China[i]);
				}
			}
			if (checker == 2)
			{
				for (int i = 0; i <= 60; i++)
				{
					bs.Add(t.Usa[i]);
				}
			}
			if (checker == 3)
			{
				for (int i = 0; i <= 60; i++)
				{
					bs.Add(t.India[i]);
				}
			}
			dataGridView1.DataSource = bs;
			dataGridView1.AutoGenerateColumns = true;
		}

	}
}
