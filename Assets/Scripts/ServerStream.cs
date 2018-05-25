using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class ServerStream : MonoBehaviour {

	public static List<string> dataList;
    public static List<string> dataList1;           // for updating PCP with change in dataset
    public static List<string> Reptile; public static List<string> Reptile1;
    public static List<string> algae; public static List<string> algae1;
    public static List<string> Amphibian; public static List<string> Amphibian1;
    public static List<string> Fish; public static List<string> Fish1;
    public static List<string> Mammal; public static List<string> Mammal1;
    public static List<string> Bird; public static List<string> Bird1;
    public static List<string> Plant1; public static List<string> Plant11;
    public static List<string> Plant2; public static List<string> Plant21;
    public static List<string> Plant3; public static List<string> Plant31;
    public static List<string> Plant5;
    public static List<string> Plant6;
    public static List<string> Plant7;
    private static List<string> pcp;
    static List<List<string>> allSpecies = new List<List<string>>();
    public static List<string> allNames = new List<string>() {"Algae", "Amphibian", "Bird", "Fish", "Insect", "Mammal", "Microbes", "Misc Animal", "Arthropod",
    "Mollusca", "Fungi", "Plant", "Reptile", "Worm"};
    static int iter = 0;

    void Start()
    {
        // Misc Animal         
        dataList = new List<string>() {"Astatumen_trinacriae", "Diphascon_Diphascon_higginsi", "Echiniscus_virginicus", "Hypsibius_cf_dujardini",
        "Hypsibius_convergens", "Macrobiotus_hufelandi", "Macrobiotus_martini", "Macrobiotus_tonollii", "Paramacrobiotus_tonollii", "Pseudechiniscus_suillus_group"};
        dataList1 = new List<string>() {"Astatumen_trinacriae", "Diphascon_Diphascon_higginsi", "Echiniscus_virginicus", "Hypsibius_cf_dujardini",
        "Hypsibius_convergens", "Macrobiotus_hufelandi", "Macrobiotus_martini", "Macrobiotus_tonollii", "Paramacrobiotus_tonollii", "Pseudechiniscus_suillus_group"};

        // Reptile              
        Reptile = new List<string>() {"Packera_anonyma", "Podophyllum_peltatum", "Asplenium_montanum", "Salix_nigra", "Verbesina_occidentalis", "Carex_laxiflora_v_laxiflora",
        "Viola_macloskeyi_variety", "Verbesina_alternifolia", "Campanulastrum_americanum", "Luzula_acuminata_variety"  };
        allSpecies.Add(Reptile);
        Reptile1 = new List<string>() {"Packera_anonyma", "Podophyllum_peltatum", "Asplenium_montanum", "Salix_nigra", "Verbesina_occidentalis", "Carex_laxiflora_v_laxiflora",
        "Viola_macloskeyi_variety", "Verbesina_alternifolia", "Campanulastrum_americanum", "Luzula_acuminata_variety"  };

        // Algae                
        algae = new List<string>() { "Cryptotaenia_canadensis", "Viola_cucullata", "Carex_brunnescens_sphaerostachya", "Solidago_altissima_v_altissima", "Juniperus_virginiana_v_virginiana",
        "Festuca_subverticillata", "Muhlenbergia_tenuiflora", "Thalictrum_clavatum", "Eurybia_surculosa", "Eupatorium_rotundifolium_variety"};
        allSpecies.Add(algae);
        algae1 = new List<string>() { "Cryptotaenia_canadensis", "Viola_cucullata", "Carex_brunnescens_sphaerostachya", "Solidago_altissima_v_altissima", "Juniperus_virginiana_v_virginiana",
        "Festuca_subverticillata", "Muhlenbergia_tenuiflora", "Thalictrum_clavatum", "Eurybia_surculosa", "Eupatorium_rotundifolium_variety"};

        //Amphibian
        Amphibian = new List<string>(){ "Anaxyrus_americanus", "Desmognathus_marmoratus", "Eurycea_longicauda_longicauda", "Gyrinophilus_porphyriticus",
        "Gyrinophilus_porphyriticus_danielsi", "Hyla_chrysoscelis", "Lithobates_clamitans_melanota", "Lithobates_sylvaticus", "Pseudacris_crucifer", "Pseudotriton_ruber"};
        allSpecies.Add(Amphibian);
        Amphibian1 = new List<string>(){ "Anaxyrus_americanus", "Desmognathus_marmoratus", "Eurycea_longicauda_longicauda", "Gyrinophilus_porphyriticus",
        "Gyrinophilus_porphyriticus_danielsi", "Hyla_chrysoscelis", "Lithobates_clamitans_melanota", "Lithobates_sylvaticus", "Pseudacris_crucifer", "Pseudotriton_ruber"};
        
        // Fish                 
        Fish = new List<string>() { "Percina_evides", "Hybopsis_amblops", "Salvelinus_fontinalis", "Clinostomus_funduloides", "Notropis_rubricroceus", "Campostoma_oligolepis",
        "Rhinichthys_obtusus", "Ambloplites_rupestris", "Salmo_trutta", "Notropis_telescopus"};
        allSpecies.Add(Fish);
        Fish1 = new List<string>() { "Percina_evides", "Hybopsis_amblops", "Salvelinus_fontinalis", "Clinostomus_funduloides", "Notropis_rubricroceus", "Campostoma_oligolepis",
        "Rhinichthys_obtusus", "Ambloplites_rupestris", "Salmo_trutta", "Notropis_telescopus"};

        // Mammal & non-vascular plant & mollusca      
        Mammal = new List<string>() { "Brotherella_recurvans", "Dicranodontium_denudatum", "Dicranum_scoparium", "Hypnum_imponens", "Polytrichum_pallidisetum",
        "Steerecleus_serrulatum", "Haplotrema_concavum", "Mesodon_normalis", "Mesomphix_andrewsae", "Blarina_brevicauda" };
        allSpecies.Add(Mammal);
        Mammal1 = new List<string>() { "Brotherella_recurvans", "Dicranodontium_denudatum", "Dicranum_scoparium", "Hypnum_imponens", "Polytrichum_pallidisetum",
        "Steerecleus_serrulatum", "Haplotrema_concavum", "Mesodon_normalis", "Mesomphix_andrewsae", "Blarina_brevicauda" };

        // Bird               
        Bird = new List<string>() {  "Cornus_amomum", "Viola_x_palmata", "Hypericum_hypericoides", "Trillium_grandiflorum", "Astilbe_biternata", "Lobelia_cardinalis",
        "Goodyera_repens", "Gamochaeta_purpurea", "Arundinaria_gigantea_gigantea", "Heuchera_americana"};
        allSpecies.Add(Bird);
        Bird1 = new List<string>() {  "Cornus_amomum", "Viola_x_palmata", "Hypericum_hypericoides", "Trillium_grandiflorum", "Astilbe_biternata", "Lobelia_cardinalis",
        "Goodyera_repens", "Gamochaeta_purpurea", "Arundinaria_gigantea_gigantea", "Heuchera_americana"};

        // Plant (1st set)    
        Plant1 = new List<string>() { "Ulmus_alata", "Pilea_pumila", "Rhus_glabra", "Packera_aurea", "Cuscuta_rostrata", "Prunus_americana", "Aralia_racemosa",
        "Eupatorium_fistulosum", "Stewartia_ovata", "Fragaria_virginiana"};
        allSpecies.Add(Plant1);                     // 80 species  3605 DataPoints
        Plant11 = new List<string>() { "Ulmus_alata", "Pilea_pumila", "Rhus_glabra", "Packera_aurea", "Cuscuta_rostrata", "Prunus_americana", "Aralia_racemosa",
        "Eupatorium_fistulosum", "Stewartia_ovata", "Fragaria_virginiana"};

        // Plant (2nd set)      
        Plant2 = new List<string>() { "Salix_sericea", "Geum_canadense", "Lespedeza_hirta", "Chelone_lyonii", "Polygonum_sagittatum", "Stachys_clingmanii", "Carex_swanii",
        "Mitella_diphylla", "Chrysopsis_mariana", "Poa_alsodes" };
        allSpecies.Add(Plant2);
        Plant21 = new List<string>() { "Salix_sericea", "Geum_canadense", "Lespedeza_hirta", "Chelone_lyonii", "Polygonum_sagittatum", "Stachys_clingmanii", "Carex_swanii",
        "Mitella_diphylla", "Chrysopsis_mariana", "Poa_alsodes" };

        // Plant (3rd set)     
        Plant3 = new List<string>() { "Carya_ovata", "Juncus_tenuis_variety", "Cinna_latifolia", "Diervilla_sessilifolia", "Vitis_vulpina", "Juncus_effusus_v_solutus",
        "Stellaria_corei", "Quercus_stellata", "Carex_laxiflora_variety", "Silene_virginica" };
        allSpecies.Add(Plant3);                     // 100 species  4276 Datapoints
        Plant31 = new List<string>() { "Carya_ovata", "Juncus_tenuis_variety", "Cinna_latifolia", "Diervilla_sessilifolia", "Vitis_vulpina", "Juncus_effusus_v_solutus",
        "Stellaria_corei", "Quercus_stellata", "Carex_laxiflora_variety", "Silene_virginica" };


        // Plant (6th set)     
        Plant6 = new List<string>() { "Packera_anonyma", "Podophyllum_peltatum", "Asplenium_montanum", "Salix_nigra", "Verbesina_occidentalis", "Carex_laxiflora_v_laxiflora",
        "Viola_macloskeyi_variety", "Verbesina_alternifolia", "Campanulastrum_americanum", "Luzula_acuminata_variety" };
        //allSpecies.Add(Plant6);



        //used for all imagres
        //pcp = new List<string>() {"Anaxyrus_americanus", "Desmognathus_marmoratus", "Eurycea_longicauda_longicauda", "Gyrinophilus_porphyriticus",
        //"Gyrinophilus_porphyriticus_danielsi", "Hyla_chrysoscelis", "Lithobates_clamitans_melanota", "Lithobates_sylvaticus", "Pseudacris_crucifer", "Pseudotriton_ruber", "Percina_evides",
        //"Cornus_amomum", "Viola_x_palmata", "Hypericum_hypericoides", "Trillium_grandiflorum", "Astilbe_biternata", "Lobelia_cardinalis",
        //"Goodyera_repens", "Gamochaeta_purpurea", "Arundinaria_gigantea_gigantea", "Heuchera_americana"};

       

        DataManager.LoadEnvData("species_parallel_allSpecies", 49, Plant31);
        TrackableMonitor.UIChange = true;
    }

    public static void newData() {
        if (iter < allSpecies.Count)
        {
            dataList = allSpecies[iter];
        }
        iter++;
        if(iter == allSpecies.Count)
        {
            SmokeyController.ONCEE = true;
        }
    }

    public static void LoadNext()
	{
		if (dataList == null)
		{
			dataList = new List<string>();
		}
		DataManager.LoadData(dataList[0]);
		dataList.RemoveAt(0);
	}	
}