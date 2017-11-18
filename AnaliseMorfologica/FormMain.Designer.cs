namespace AnaliseMorfologica
{
	partial class FormMain
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.panelTopo = new System.Windows.Forms.Panel();
			this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
			this.btnAbrir = new System.Windows.Forms.Button();
			this.btnSalvar = new System.Windows.Forms.Button();
			this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
			this.split = new System.Windows.Forms.SplitContainer();
			this.imgEntrada = new System.Windows.Forms.PictureBox();
			this.imgSaida = new System.Windows.Forms.PictureBox();
			this.btnProcessar = new System.Windows.Forms.Button();
			this.panelTopo.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.split)).BeginInit();
			this.split.Panel1.SuspendLayout();
			this.split.Panel2.SuspendLayout();
			this.split.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.imgEntrada)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.imgSaida)).BeginInit();
			this.SuspendLayout();
			// 
			// panelTopo
			// 
			this.panelTopo.Controls.Add(this.btnProcessar);
			this.panelTopo.Controls.Add(this.btnSalvar);
			this.panelTopo.Controls.Add(this.btnAbrir);
			this.panelTopo.Dock = System.Windows.Forms.DockStyle.Top;
			this.panelTopo.Location = new System.Drawing.Point(0, 0);
			this.panelTopo.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.panelTopo.Name = "panelTopo";
			this.panelTopo.Size = new System.Drawing.Size(651, 62);
			this.panelTopo.TabIndex = 0;
			// 
			// openFileDialog
			// 
			this.openFileDialog.Filter = "Imagens|*.gif;*.png;*.jpg;*.jpeg;*.bmp";
			// 
			// btnAbrir
			// 
			this.btnAbrir.Location = new System.Drawing.Point(14, 15);
			this.btnAbrir.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.btnAbrir.Name = "btnAbrir";
			this.btnAbrir.Size = new System.Drawing.Size(130, 30);
			this.btnAbrir.TabIndex = 0;
			this.btnAbrir.Text = "Abrir imagem...";
			this.btnAbrir.UseVisualStyleBackColor = true;
			this.btnAbrir.Click += new System.EventHandler(this.btnAbrir_Click);
			// 
			// btnSalvar
			// 
			this.btnSalvar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnSalvar.Location = new System.Drawing.Point(508, 15);
			this.btnSalvar.Margin = new System.Windows.Forms.Padding(4);
			this.btnSalvar.Name = "btnSalvar";
			this.btnSalvar.Size = new System.Drawing.Size(130, 30);
			this.btnSalvar.TabIndex = 2;
			this.btnSalvar.Text = "Salvar imagem...";
			this.btnSalvar.UseVisualStyleBackColor = true;
			this.btnSalvar.Click += new System.EventHandler(this.btnSalvar_Click);
			// 
			// saveFileDialog
			// 
			this.saveFileDialog.Filter = "Imagem PNG|*.png";
			// 
			// split
			// 
			this.split.Dock = System.Windows.Forms.DockStyle.Fill;
			this.split.Location = new System.Drawing.Point(0, 62);
			this.split.Name = "split";
			// 
			// split.Panel1
			// 
			this.split.Panel1.Controls.Add(this.imgEntrada);
			// 
			// split.Panel2
			// 
			this.split.Panel2.Controls.Add(this.imgSaida);
			this.split.Size = new System.Drawing.Size(651, 309);
			this.split.SplitterDistance = 325;
			this.split.TabIndex = 1;
			// 
			// imgEntrada
			// 
			this.imgEntrada.BackColor = System.Drawing.Color.DimGray;
			this.imgEntrada.Cursor = System.Windows.Forms.Cursors.Hand;
			this.imgEntrada.Dock = System.Windows.Forms.DockStyle.Fill;
			this.imgEntrada.Location = new System.Drawing.Point(0, 0);
			this.imgEntrada.Name = "imgEntrada";
			this.imgEntrada.Size = new System.Drawing.Size(325, 309);
			this.imgEntrada.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
			this.imgEntrada.TabIndex = 0;
			this.imgEntrada.TabStop = false;
			this.imgEntrada.Click += new System.EventHandler(this.img_Click);
			// 
			// imgSaida
			// 
			this.imgSaida.BackColor = System.Drawing.Color.DimGray;
			this.imgSaida.Cursor = System.Windows.Forms.Cursors.Hand;
			this.imgSaida.Dock = System.Windows.Forms.DockStyle.Fill;
			this.imgSaida.Location = new System.Drawing.Point(0, 0);
			this.imgSaida.Name = "imgSaida";
			this.imgSaida.Size = new System.Drawing.Size(322, 309);
			this.imgSaida.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
			this.imgSaida.TabIndex = 0;
			this.imgSaida.TabStop = false;
			this.imgSaida.Click += new System.EventHandler(this.img_Click);
			// 
			// btnProcessar
			// 
			this.btnProcessar.Anchor = System.Windows.Forms.AnchorStyles.Top;
			this.btnProcessar.Location = new System.Drawing.Point(260, 15);
			this.btnProcessar.Margin = new System.Windows.Forms.Padding(4);
			this.btnProcessar.Name = "btnProcessar";
			this.btnProcessar.Size = new System.Drawing.Size(130, 30);
			this.btnProcessar.TabIndex = 1;
			this.btnProcessar.Text = "Processar...";
			this.btnProcessar.UseVisualStyleBackColor = true;
			this.btnProcessar.Click += new System.EventHandler(this.btnProcessar_Click);
			// 
			// FormMain
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(651, 371);
			this.Controls.Add(this.split);
			this.Controls.Add(this.panelTopo);
			this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			this.MinimumSize = new System.Drawing.Size(450, 350);
			this.Name = "FormMain";
			this.Text = "Teste";
			this.panelTopo.ResumeLayout(false);
			this.split.Panel1.ResumeLayout(false);
			this.split.Panel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.split)).EndInit();
			this.split.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.imgEntrada)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.imgSaida)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Panel panelTopo;
		private System.Windows.Forms.Button btnSalvar;
		private System.Windows.Forms.Button btnAbrir;
		private System.Windows.Forms.OpenFileDialog openFileDialog;
		private System.Windows.Forms.SaveFileDialog saveFileDialog;
		private System.Windows.Forms.SplitContainer split;
		private System.Windows.Forms.PictureBox imgEntrada;
		private System.Windows.Forms.PictureBox imgSaida;
		private System.Windows.Forms.Button btnProcessar;
	}
}

