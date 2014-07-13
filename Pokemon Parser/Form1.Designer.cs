namespace Pokemon_Parser
{
    partial class Form1
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
            this.btn_ParseAll = new System.Windows.Forms.Button();
            this.btn_ParseGen = new System.Windows.Forms.Button();
            this.btn_ParseOne = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txt_DexNumber = new System.Windows.Forms.TextBox();
            this.txt_Generation = new System.Windows.Forms.TextBox();
            this.btn_ParseItems = new System.Windows.Forms.Button();
            this.btn_ParseBerries = new System.Windows.Forms.Button();
            this.btn_ParseTMs = new System.Windows.Forms.Button();
            this.btn_ParseAbilities = new System.Windows.Forms.Button();
            this.btn_ParseAttacks = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btn_ParseAll
            // 
            this.btn_ParseAll.Location = new System.Drawing.Point(190, 67);
            this.btn_ParseAll.Name = "btn_ParseAll";
            this.btn_ParseAll.Size = new System.Drawing.Size(75, 23);
            this.btn_ParseAll.TabIndex = 0;
            this.btn_ParseAll.Text = "Parse All";
            this.btn_ParseAll.UseVisualStyleBackColor = true;
            this.btn_ParseAll.Click += new System.EventHandler(this.btn_ParseAll_Click);
            // 
            // btn_ParseGen
            // 
            this.btn_ParseGen.Location = new System.Drawing.Point(190, 38);
            this.btn_ParseGen.Name = "btn_ParseGen";
            this.btn_ParseGen.Size = new System.Drawing.Size(75, 23);
            this.btn_ParseGen.TabIndex = 1;
            this.btn_ParseGen.Text = "Parse Gen";
            this.btn_ParseGen.UseVisualStyleBackColor = true;
            this.btn_ParseGen.Click += new System.EventHandler(this.btn_ParseGen_Click);
            // 
            // btn_ParseOne
            // 
            this.btn_ParseOne.Location = new System.Drawing.Point(190, 9);
            this.btn_ParseOne.Name = "btn_ParseOne";
            this.btn_ParseOne.Size = new System.Drawing.Size(75, 23);
            this.btn_ParseOne.TabIndex = 2;
            this.btn_ParseOne.Text = "Parse";
            this.btn_ParseOne.UseVisualStyleBackColor = true;
            this.btn_ParseOne.Click += new System.EventHandler(this.btn_ParseOne_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Dex Number";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Generation";
            // 
            // txt_DexNumber
            // 
            this.txt_DexNumber.Location = new System.Drawing.Point(84, 12);
            this.txt_DexNumber.Name = "txt_DexNumber";
            this.txt_DexNumber.Size = new System.Drawing.Size(100, 20);
            this.txt_DexNumber.TabIndex = 5;
            // 
            // txt_Generation
            // 
            this.txt_Generation.Location = new System.Drawing.Point(84, 38);
            this.txt_Generation.Name = "txt_Generation";
            this.txt_Generation.Size = new System.Drawing.Size(100, 20);
            this.txt_Generation.TabIndex = 6;
            // 
            // btn_ParseItems
            // 
            this.btn_ParseItems.Location = new System.Drawing.Point(190, 96);
            this.btn_ParseItems.Name = "btn_ParseItems";
            this.btn_ParseItems.Size = new System.Drawing.Size(75, 23);
            this.btn_ParseItems.TabIndex = 7;
            this.btn_ParseItems.Text = "Parse Items";
            this.btn_ParseItems.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.btn_ParseItems.UseVisualStyleBackColor = true;
            this.btn_ParseItems.Click += new System.EventHandler(this.btn_ParseItems_Click);
            // 
            // btn_ParseBerries
            // 
            this.btn_ParseBerries.Location = new System.Drawing.Point(96, 96);
            this.btn_ParseBerries.Name = "btn_ParseBerries";
            this.btn_ParseBerries.Size = new System.Drawing.Size(88, 23);
            this.btn_ParseBerries.TabIndex = 8;
            this.btn_ParseBerries.Text = "Parse Berries";
            this.btn_ParseBerries.UseVisualStyleBackColor = true;
            this.btn_ParseBerries.Click += new System.EventHandler(this.btn_ParseBerries_Click);
            // 
            // btn_ParseTMs
            // 
            this.btn_ParseTMs.Location = new System.Drawing.Point(15, 96);
            this.btn_ParseTMs.Name = "btn_ParseTMs";
            this.btn_ParseTMs.Size = new System.Drawing.Size(75, 23);
            this.btn_ParseTMs.TabIndex = 9;
            this.btn_ParseTMs.Text = "Parse TMs";
            this.btn_ParseTMs.UseVisualStyleBackColor = true;
            this.btn_ParseTMs.Click += new System.EventHandler(this.btn_ParseTMs_Click);
            // 
            // btn_ParseAbilities
            // 
            this.btn_ParseAbilities.Location = new System.Drawing.Point(15, 125);
            this.btn_ParseAbilities.Name = "btn_ParseAbilities";
            this.btn_ParseAbilities.Size = new System.Drawing.Size(95, 23);
            this.btn_ParseAbilities.TabIndex = 10;
            this.btn_ParseAbilities.Text = "Parse Abilities";
            this.btn_ParseAbilities.UseVisualStyleBackColor = true;
            this.btn_ParseAbilities.Click += new System.EventHandler(this.btn_ParseAbilities_Click);
            // 
            // btn_ParseAttacks
            // 
            this.btn_ParseAttacks.Location = new System.Drawing.Point(117, 125);
            this.btn_ParseAttacks.Name = "btn_ParseAttacks";
            this.btn_ParseAttacks.Size = new System.Drawing.Size(83, 23);
            this.btn_ParseAttacks.TabIndex = 11;
            this.btn_ParseAttacks.Text = "Parse Moves";
            this.btn_ParseAttacks.UseVisualStyleBackColor = true;
            this.btn_ParseAttacks.Click += new System.EventHandler(this.btn_ParseAttacks_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(273, 158);
            this.Controls.Add(this.btn_ParseAttacks);
            this.Controls.Add(this.btn_ParseAbilities);
            this.Controls.Add(this.btn_ParseTMs);
            this.Controls.Add(this.btn_ParseBerries);
            this.Controls.Add(this.btn_ParseItems);
            this.Controls.Add(this.txt_Generation);
            this.Controls.Add(this.txt_DexNumber);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btn_ParseOne);
            this.Controls.Add(this.btn_ParseGen);
            this.Controls.Add(this.btn_ParseAll);
            this.Name = "Form1";
            this.Text = "Pokemon Parser";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_ParseAll;
        private System.Windows.Forms.Button btn_ParseGen;
        private System.Windows.Forms.Button btn_ParseOne;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txt_DexNumber;
        private System.Windows.Forms.TextBox txt_Generation;
        private System.Windows.Forms.Button btn_ParseItems;
        private System.Windows.Forms.Button btn_ParseBerries;
        private System.Windows.Forms.Button btn_ParseTMs;
        private System.Windows.Forms.Button btn_ParseAbilities;
        private System.Windows.Forms.Button btn_ParseAttacks;
    }
}

