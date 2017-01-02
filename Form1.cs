using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace The_Quest
{
    public partial class Form1 : Form
    {
        private Game game;
        private Random random = new Random();
        public Form1()
        {
            InitializeComponent();
            game = new Game(new Rectangle(99, 17, 614, 239));
            game.NewLevel(random);
            UpdateCharacters();

        }

        public void UpdateCharacters()
        {
            playerPictureBox.Location = game.PlayerLocation;
            playerHitPoints.Text = game.PlayerHitPoints.ToString();
            playerPictureBox.Visible = true;

            bool showBat = false;
            bool showGhost = false;
            bool showGhoul = false;
            int enemiesShown = 0;
            batHitPoints.Text = "";
            ghostHitPoints.Text = "";
            ghoulHitPoints.Text = "";

            foreach (Enemy enemy in game.Enemies)
            {
                if(enemy is Bat)
                {
                    bat.Location = enemy.Location;
                    batHitPoints.Text = enemy.HitPoints.ToString();
                    if (enemy.HitPoints > 0)
                    {
                        showBat = true;
                        enemiesShown++;
                    }
                }
                if (enemy is Ghost)
                {
                    ghost.Location = enemy.Location;
                    ghostHitPoints.Text = enemy.HitPoints.ToString();
                    if (enemy.HitPoints > 0)
                    {
                        showGhost = true;
                        enemiesShown++;
                    }
                }
                if (enemy is Ghoul)
                {
                    ghoul.Location = enemy.Location;
                    ghoulHitPoints.Text = enemy.HitPoints.ToString();
                    if (enemy.HitPoints > 0)
                    {
                        showGhoul = true;
                        enemiesShown++;
                    }
                }

            }
            bat.Visible = showBat;
            ghost.Visible = showGhost;
            ghoul.Visible = showGhoul;

            sword.Visible = false;
            bow.Visible = false;
            redPotion.Visible = false;
            bluePotion.Visible = false;
            mace.Visible = false;

            Control weaponControl = null;

            switch (game.WeaponInRoom.Name)
            {
                case "Sword":
                    weaponControl = sword;
                    break;
                case "Bow":
                    weaponControl = bow;
                    break;
                case "Red potion":
                    weaponControl = redPotion;
                    break;
                case "Blue potion":
                    weaponControl = bluePotion;
                    break;
                case "Mace":
                    weaponControl = mace;
                    break;
            }
            

            swordInventory.Visible = false;
            bowInventory.Visible = false;
            bluePotionInventory.Visible = false;
            redPotionInventory.Visible = false;
            maceInventory.Visible = false;

            foreach(string name in game.PlayerWeapons)
            {
                switch (name)
                {
                    case "Sword":
                        swordInventory.Visible = true;
                        break;
                    case "Bow":
                        bowInventory.Visible = true;
                        break;
                    case "Red potion":
                        redPotionInventory.Visible = true;
                        break;
                    case "Blue potion":
                        bluePotionInventory.Visible = true;
                        break;
                    case "Mace":
                        maceInventory.Visible = true;
                        break;
                }
            }

            
            if(game.WeaponInRoom.PickedUp && weaponControl != null)
                weaponControl.Visible = false;
            else if(weaponControl != null)
            {
                weaponControl.Location = game.WeaponInRoom.Location;
                weaponControl.Visible = true;
            }
                
            if (game.PlayerHitPoints <= 0)
            {
                MessageBox.Show("You died");
                Application.Exit();
            }

            if (enemiesShown < 1)
            {
                MessageBox.Show("You have defeated the enemies on this level");
                game.NewLevel(random);
                UpdateCharacters();
            }
        }

        private void swordInventory_Click(object sender, EventArgs e)
        {
            if (game.CheckPlayerInventory("Sword"))
            {
                swordInventory.BorderStyle = BorderStyle.FixedSingle;
                bluePotionInventory.BorderStyle = BorderStyle.None;
                bowInventory.BorderStyle = BorderStyle.None;
                redPotionInventory.BorderStyle = BorderStyle.None;
                maceInventory.BorderStyle = BorderStyle.None;

                game.Equip("Sword");

                groupBox2.Text = "Attack";
                leftAttack.Enabled = true;
                rightAttack.Enabled = true;
                downAttack.Enabled = true;
            }
        }

        private void bluePotionInventory_Click(object sender, EventArgs e)
        {
            if (game.CheckPlayerInventory("Blue potion"))
            {
                swordInventory.BorderStyle = BorderStyle.None;
                bluePotionInventory.BorderStyle = BorderStyle.FixedSingle;
                bowInventory.BorderStyle = BorderStyle.None;
                redPotionInventory.BorderStyle = BorderStyle.None;
                maceInventory.BorderStyle = BorderStyle.None;

                game.Equip("Blue potion");

                groupBox2.Text = "Heal";
                leftAttack.Enabled = false;
                rightAttack.Enabled = false;
                downAttack.Enabled = false;
            }
        }

        private void bowInventory_Click(object sender, EventArgs e)
        {
            if (game.CheckPlayerInventory("Bow"))
            {
                swordInventory.BorderStyle = BorderStyle.None;
                bluePotionInventory.BorderStyle = BorderStyle.None;
                bowInventory.BorderStyle = BorderStyle.FixedSingle;
                redPotionInventory.BorderStyle = BorderStyle.None;
                maceInventory.BorderStyle = BorderStyle.None;

                game.Equip("Bow");

                groupBox2.Text = "Attack";
                leftAttack.Enabled = true;
                rightAttack.Enabled = true;
                downAttack.Enabled = true;
            }
        }

        private void redPotionInventory_Click(object sender, EventArgs e)
        {
            if (game.CheckPlayerInventory("Red potion"))
            {
                swordInventory.BorderStyle = BorderStyle.None;
                bluePotionInventory.BorderStyle = BorderStyle.None;
                bowInventory.BorderStyle = BorderStyle.None;
                redPotionInventory.BorderStyle = BorderStyle.FixedSingle;
                maceInventory.BorderStyle = BorderStyle.None;

                game.Equip("Red potion");

                groupBox2.Text = "Heal";
                leftAttack.Enabled = false;
                rightAttack.Enabled = false;
                downAttack.Enabled = false;

            }
        }

        private void maceInventory_Click(object sender, EventArgs e)
        {
            if (game.CheckPlayerInventory("Mace"))
            {
                swordInventory.BorderStyle = BorderStyle.None;
                bluePotionInventory.BorderStyle = BorderStyle.None;
                bowInventory.BorderStyle = BorderStyle.None;
                redPotionInventory.BorderStyle = BorderStyle.None;
                maceInventory.BorderStyle = BorderStyle.FixedSingle;

                game.Equip("Mace");

                groupBox2.Text = "Attack";
                leftAttack.Enabled = true;
                rightAttack.Enabled = true;
                downAttack.Enabled = true;
            }
        }

        private void up_Click(object sender, EventArgs e)
        {
            game.Move(Direction.Up, random);
            UpdateCharacters();
        }

        private void left_Click(object sender, EventArgs e)
        {
            game.Move(Direction.Left, random);
            UpdateCharacters();
        }

        private void down_Click(object sender, EventArgs e)
        {
            game.Move(Direction.Down, random);
            UpdateCharacters();
        }

        private void right_Click(object sender, EventArgs e)
        {
            game.Move(Direction.Right, random);
            UpdateCharacters();
        }

        private void upAttack_Click(object sender, EventArgs e)
        {
            game.Attack(Direction.Up, random);
            UpdateCharacters();
        }

        private void rightAttack_Click(object sender, EventArgs e)
        {
            game.Attack(Direction.Right, random);
            UpdateCharacters();
        }

        private void leftAttack_Click(object sender, EventArgs e)
        {
            game.Attack(Direction.Left, random);
            UpdateCharacters();
        }

        private void downAttack_Click(object sender, EventArgs e)
        {
            game.Attack(Direction.Down, random);
            UpdateCharacters();
        }
    }
}
