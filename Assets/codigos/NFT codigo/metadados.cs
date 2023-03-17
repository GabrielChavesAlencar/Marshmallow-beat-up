using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class metadados 
{
   public static int num_perso=0;
   public static string description = "";
   public static string name = "";
   public static string atributos = "[]";
   public static string boca_text;
   public static string olho_text;
   public static string corpo_text;
   public static string camisa_text;

   public static string cabeca_text;

   public static string bracos_text;
   public static string pernas_text;

   public static string torax_text;
   public static void criarAtributos(){
     if(num_perso==0){criarAtributos_ape();}
     else{criarAtributos_dog();}
   }
   public static void criarAtributos_dog  () {
        atualizar_dog();
        name = "DOG";
        description = "the NFT customizable dog";
        atributos ="\"attributes\":[{ \"trait_type\": \"eyes\", \"value\": \""+  olho_text +"\" },{ \"trait_type\": \"mouth\", \"value\": \""+boca_text +"\" },{ \"trait_type\": \"body\", \"value\": \""+corpo_text+"\" },{ \"trait_type\": \"clothes\", \"value\": \""+camisa_text+"\" }]";
   }
    public static void criarAtributos_ape  () {
        atualizar_ape();
        name = "APE";
        description = "the NFT customizable ape";
        atributos ="\"attributes\":[{ \"trait_type\": \"head\", \"value\": \""+  cabeca_text +"\" },{ \"trait_type\": \"chest\", \"value\": \""+torax_text +"\" },{ \"trait_type\": \"arms\", \"value\": \""+bracos_text+"\" },{ \"trait_type\": \"legs\", \"value\": \""+pernas_text+"\" }]";
   }
   public static void  atualizar_dog() {
        boca();
        corpo();
        roupas();
        olhos();
   }

   public static void  atualizar_ape() {
        cabeca_ape();
        torax_ape();
        bracos_ape();
        pernas_ape();
   }


   public static  void cabeca_ape(){
        int num_cabeca = bancodedados.carregarint("cabeca");
       switch (num_cabeca) {
        case 0:
            cabeca_text = "Blue";
            break;
        case 1:
            cabeca_text = "Mutant";
            break;
        case 2:
            cabeca_text = "Black Tuxedo";
            break;
        default :
            cabeca_text = "default";
            break;
       }
   }
   public static  void bracos_ape(){
        int num_bracos = bancodedados.carregarint("bracos");
       switch (num_bracos) {
        case 0:
            bracos_text = "Blue";
            break;
        case 1:
            bracos_text = "Mutant";
            break;
        case 2:
            bracos_text = "Black Tuxedo";
            break;
        default :
            bracos_text = "default";
            break;
       }
   }
   public static  void torax_ape(){
        int num_torax = bancodedados.carregarint("torax");
       switch (num_torax) {
        case 0:
            torax_text = "Blue";
            break;
        case 1:
            torax_text = "Mutant";
            break;
        case 2:
            torax_text = "Black Tuxedo";
            break;
        default :
            torax_text = "default";
            break;
       }
   }
   public static  void pernas_ape(){
        int num_pernas = bancodedados.carregarint("pernas");
       switch (num_pernas) {
        case 0:
            pernas_text = "Blue";
            break;
        case 1:
            pernas_text = "Mutant";
            break;
        case 2:
            pernas_text = "Black Tuxedo";
            break;
        default :
            pernas_text = "default";
            break;
       }
   }


   public static void boca(){
        int num_boca = bancodedados.carregarint("Boca_dog");
       switch (num_boca) {
        case 0:
            boca_text = "Bubblegum";
            break;
        case 1:
            boca_text = "Cigar Baby";
            break;
        case 2:
            boca_text = "Dagger Baby";
            break;
        case 3:
            boca_text = "Kazoo Baby";
            break;
        case 4:
            boca_text = "Party Horn";
            break;
        case 5:
            boca_text = "Pipe Baby";
            break;
        case 6:
            boca_text = "Pizza Baby";
            break;
        case 7:
            boca_text = "Diamond Gril Baby";
            break;
        case 8:
            boca_text = "Discomfort Baby";
            break;
        case 9:
            boca_text = "Grin Gold";
            break;
        case 10:
            boca_text = "Grin Multicolored";
            break;
        case 11:
            boca_text = "Phoneme L";
            break;
        case 12:
            boca_text = "Phoneme Ooo";
            break;
        case 13:
            boca_text = "Phoneme Wah";
            break;
        case 14:
            boca_text = "Rage Baby";
            break;
        case 15:
            boca_text = "Small Grin";
            break;
        case 16:
            boca_text = "Tongue out";
            break;
        case 17:
            boca_text = "Bored Baby";
            break;
        case 18:
            boca_text = "Bubblegum_2";
            break;
        case 19:
            boca_text = "Cigar Baby_2";
            break;
        case 20:
            boca_text = "Cigarette Baby_2";
            break;
        case 21:
            boca_text = "Dagger Baby_2";
            break;
        case 22:
            boca_text = "Kazoo Baby_2";
            break;
        case 23:
            boca_text = "Party Horn_2";
            break;
        case 24:
            boca_text = "Pipe Baby_2";
            break;
        case 25:
            boca_text = "Pizza Baby_2";
            break;
        case 26:
            boca_text = "Unsshaven Bored Baby";
            break;
        case 27:
            boca_text = "Unsshaven Bubblegum";
            break;
        case 28:
            boca_text = "Unsshaven Cigar Baby";
            break;
        case 29:
            boca_text = "Unsshaven Cigarette Baby";
            break;
        case 30:
            boca_text = "Unsshaven Dagger Baby";
            break;
        case 31:
            boca_text = "Unsshaven Kazoo Baby";
            break;
        case 32:
            boca_text = "Unsshaven Party Horn";
            break;
        case 33:
            boca_text = "Unsshaven Pipe Baby";
            break;
        case 34:
            boca_text = "Unsshaven Pizza Baby";
            break;
        case 35:
            boca_text = "Diamond Baby_2";
            break;
        case 36:
            boca_text = "Discomfort Baby_2";
            break;
        case 37:
            boca_text = "Dumbfounded Baby";
            break;
        case 38:
            boca_text = "Grin Baby_2";
            break;
        case 39:
            boca_text = "Grin Gold_2";
            break;
        case 40:
            boca_text = "Grin Multicolored_2";
            break;
        case 41:
            boca_text = "Jovial Baby";
            break;
        case 42:
            boca_text = "Phoneme L_2";
            break;
        case 43:
            boca_text = "Phoneme Oh";
            break;
        case 44:
            boca_text = "Phoneme Ooo_2";
            break;
        case 45:
            boca_text = "Phoneme Wah_2";
            break;
        case 46:
            boca_text = "Rage Baby_2";
            break;
        case 47:
            boca_text = "Small Grin_2";
            break;
        case 48:
            boca_text = "Tongue Out_2";
            break;
        case 49:
            boca_text = "Vuh Baby";
            break;
        case 50:
            boca_text = "Vuh Baby_2";
            break;
        case 51:
            boca_text = "Cigarrete";
            break;
        case 52:
            boca_text = "Bored";
            break;
        case 53:
            boca_text = "Dumbfounded";
            break;
        case 54:
            boca_text = "Grin";
            break;
        case 55:
            boca_text = "Phoneme vuh";
            break;
        default :
            boca_text = "";
            break;
       }
   }

   public static void corpo(){
        int num_corpo = bancodedados.carregarint("Body_dog");
       switch (num_corpo) {
        case 0:
            corpo_text = "default";
            break;
        case 1:
            corpo_text = "Death Bot(Cyborg)";
            break;
        case 2:
            corpo_text = "fur DMT";
            break;
        case 3:
            corpo_text = "fur Noise";
            break;
        case 4:
            corpo_text = "fur Red";
            break;
        case 5:
            corpo_text = "Robot";
            break;
        case 6:
            corpo_text = "fur Black";
            break;
        case 7:
            corpo_text = "fur Blue";
            break;
        case 8:
            corpo_text = "Cream";
            break;
        case 9:
            corpo_text = "Death Bot";
            break;
        case 10:
            corpo_text = "fur DMT_2";
            break;
        case 11:
            corpo_text = "Gray";
            break;
        case 12:
            corpo_text = "fur Red_2";
            break;
        case 13:
            corpo_text = "Trippy";
            break;
        case 14:
            corpo_text = "Black";
            break;
        case 15:
            corpo_text = "fur Blue_2";
            break;
        case 16:
            corpo_text = "fur Brown";
            break;
        case 17:
            corpo_text = "Cheetah";
            break;
        case 18:
            corpo_text = "Cream_2";
            break;
        case 19:
            corpo_text = "Dark Brown";
            break;
        case 20:
            corpo_text = "Golden Brown";
            break;
        case 21:
            corpo_text = "Gray_2";
            break;
        case 22:
            corpo_text = "Pink";
            break;
        case 23:
            corpo_text = "fur Tan";
            break;
        case 24:
            corpo_text = "Trippy";
            break;
        case 25:
            corpo_text = "White";
            break;
        case 26:
            corpo_text = "Zombie_1";
            break;
        case 27:
            corpo_text = "Gold";
            break;
        case 28:
            corpo_text = "Zombie_2";
            break;
        case 29:
            corpo_text = "fur Brown_2";
            break;
        case 30:
            corpo_text = "fur Cheetah";
            break;
        case 31:
            corpo_text = "Dark Brown_2";
            break;
        case 32:
            corpo_text = "Golden Brown_2";
            break;
        case 33:
            corpo_text = "Noise_2";
            break;
        case 34:
            corpo_text = "Pink_2";
            break;
        case 35:
            corpo_text = "Robot_2";
            break;
        case 36:
            corpo_text = "Solid Gold";
            break;
        case 37:
            corpo_text = "fur Tan_2";
            break;
        case 38:
            corpo_text = "fur White_2";
            break;
            
        default :
            corpo_text = "default";
            break;
       }

   }

   public static void roupas(){
        int num_camiseta = bancodedados.carregarint("roupas_dog");
        switch (num_camiseta) {
            case 0:
                camisa_text = "clothes Off";
                break;
            case 1:
                camisa_text = "Black Suit";
                break;
            case 2:
                camisa_text = "Bone Tee";
                break;
            case 3:
                camisa_text = "Leather Jacket";
                break;
            case 4:
                camisa_text = "Smoking Jacket";
                break;
            case 5:
                camisa_text = "Space suit";
                break;
            case 6:
                camisa_text = "Tuxedo Tee";
                break;
            default :
                olho_text = "";
                break;
       }
   }

   public static void olhos(){
         int num_eye = bancodedados.carregarint("Eyes_dog");
         switch (num_eye) {
            case 0:
                olho_text = "3D glasses";
                break;
            case 1:
                olho_text = "Angry";
                break;
            case 2:
                olho_text = "Blindfold";
                break;
            case 3:
                olho_text = "Bloodshot_1";
                break;
            case 4:
                olho_text = "Bloodshot_2";
                break;
            case 5:
                olho_text = "Bloodshot_3";
                break;
            case 6:
                olho_text = "Bloodshot_4";
                break;
            case 7:
                olho_text = "Bloodshot_5";
                break;
            case 8:
                olho_text = "Bloodshot_6";
                break;
            case 9:
                olho_text = "Bloodshot_7";
                break;
            case 10:
                olho_text = "Bloodshot_8";
                break;
            case 11:
                olho_text = "Blue Beams_1";
                break;
            case 12:
                olho_text = "Blue Beams_2";
                break;
            case 13:
                olho_text = "Bored_1";
                break;
            case 14:
                olho_text = "Bored_2";
                break;
            case 15:
                olho_text = "Bored_3";
                break;
            case 16:
                olho_text = "Bored_4";
                break;
            case 17:
                olho_text = "Bored_5";
                break;
            case 18:
                olho_text = "Bored_6";
                break;
            case 19:
                olho_text = "Bored_7";
                break;
            case 20:
                olho_text = "Closed_1";
                break;
            case 21:
                olho_text = "Coins_1";
                break;
            case 22:
                olho_text = "Crazy";
                break;
            case 23:
                olho_text = "Cyborg";
                break;
            case 24:
                olho_text = "Eyepatch";
                break;
            case 25:
                olho_text = "Heart";
                break;
            case 26:
                olho_text = "Holographic";
                break;
            case 27:
                olho_text = "Hypnotized";
                break;
            case 28:
                olho_text = "Laser eyes";
                break;
            case 29:
                olho_text = "Robot_1";
                break;
            case 30:
                olho_text = "Robot_2";
                break;
            case 31:
                olho_text = "Robot_3";
                break;
            case 32:
                olho_text = "Robot_4";
                break;
            case 33:
                olho_text = "Robot_5";
                break;
            case 34:
                olho_text = "Robot_6";
                break;
            case 35:
                olho_text = "Sad_1";
                break;
            case 36:
                olho_text = "Sad_2";
                break;
            case 37:
                olho_text = "Sad_3";
                break;
            case 38:
                olho_text = "Sad_4";
                break;
            case 39:
                olho_text = "Sad_5";
                break;
            case 40:
                olho_text = "Sad_6";
                break;
            case 41:
                olho_text = "Sad_7";
                break;
            case 42:
                olho_text = "Sad_8";
                break;
            case 43:
                olho_text = "Sad_9";
                break;
            case 44:
                olho_text = "Sad_10";
                break;
            case 45:
                olho_text = "Sad_11";
                break;
            case 46:
                olho_text = "Scumbag_1";
                break;
            case 47:
                olho_text = "Scumbag_2";
                break;
            case 48:
                olho_text = "Sleepy";
                break;
            case 49:
                olho_text = "Sunglasses";
                break;
            case 50:
                olho_text = "Wide eyed_1";
                break;
            case 51:
                olho_text = "Wide eyed_2";
                break;
            case 52:
                olho_text = "Wide eyed_3";
                break;
            case 53:
                olho_text = "Wide eyed_4";
                break;
            case 54:
                olho_text = "Wide eyed_5";
                break;
            case 55:
                olho_text = "Wide eyed_6";
                break;
            case 56:
                olho_text = "Wide eyed_7";
                break;
            case 57:
                olho_text = "Wide eyed_8";
                break;
            case 58:
                olho_text = "Wide eyed_9";
                break;
            case 59:
                olho_text = "X eyes";
                break;
            case 60:
                olho_text = "Zombie";
                break;
            case 61:
                olho_text = "3D glasses";
                break;
            case 62:
                olho_text = "Angry";
                break;
            case 63:
                olho_text = "Blindfold";
                break;
            case 64:
                olho_text = "Bloodshot_9";
                break;
            case 65:
                olho_text = "Blue Beams_3";
                break;
            case 66:
                olho_text = "Bored_8";
                break;
            case 67:
                olho_text = "Closed_2";
                break;
            case 68:
                olho_text = "Coins_2";
                break;
            case 69:
                olho_text = "Crazy_2";
                break;
            case 70:
                olho_text = "Cyborg_2";
                break;
            case 71:
                olho_text = "Eyepatch_2";
                break;
            case 72:
                olho_text = "Heart_2";
                break;
            case 73:
                olho_text = "Heart_3";
                break;
            case 74:
                olho_text = "Holographic";
                break;
            case 75:
                olho_text = "Hypnotized";
                break;
            case 76:
                olho_text = "Laser eyes";
                break;
            case 77:
                olho_text = "Robot_7";
                break;
            case 78:
                olho_text = "Sad_12";
                break;
            case 79:
                olho_text = "Scumbag_3";
                break;
            case 80:
                olho_text = "Sleepy_2";
                break;
            case 81:
                olho_text = "Sunglasses_2";
                break;
            case 82:
                olho_text = "Wide eyed_10";
                break;
            case 83:
                olho_text = "X eyes_2";
                break;
            case 84:
                olho_text = "Zombie_2";
                break;
            default :
                olho_text = "";
                break;
         }
        
   }
}
