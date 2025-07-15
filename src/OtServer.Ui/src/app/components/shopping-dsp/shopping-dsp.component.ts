import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';

interface ShopItem {
    img: string;
    name: string;
    description: string;
    price: string;
    category: 'runas' | 'premium' | 'items' | 'variados';
}

@Component({
    selector: 'app-shopping-dsp',
    standalone: true,
    imports: [CommonModule],
    templateUrl: './shopping-dsp.component.html',
    styleUrl: './shopping-dsp.component.css'
})
export class ShoppingDspComponent {
    runas: ShopItem[] = [
        { img: 'assets/shopping/dspdf.gif', name: 'Bp de Destroy Field', description: 'Uma backpack contendo 20 runas de Destroy Field, com 60x de carga em cada runa.', price: "5 DSP's", category: 'runas' },
        { img: 'assets/shopping/dsphmm.gif', name: 'Bp de HMM', description: 'Uma backpack contendo 20 runas de Heavy Magic Missile, com 100x de carga em cada runa.', price: "5 DSP's", category: 'runas' },
        { img: 'assets/shopping/dspgfb.gif', name: 'Bp de GFB', description: 'Uma backpack contendo 20 runas de Great Fireball, com 40x de carga em cada runa.', price: "10 DSP's", category: 'runas' },
        { img: 'assets/shopping/dspuh.gif', name: 'Bp de UH', description: 'Uma backpack contendo 20 runas de Ultimate Healing, com 20x de carga em cada runa.', price: "10 DSP's", category: 'runas' },
        { img: 'assets/shopping/dspexpl.gif', name: 'Bp de Explosion', description: 'Uma backpack contendo 20 runas de Explosion, com 60x de carga em cada runa.', price: "15 DSP's", category: 'runas' },
        { img: 'assets/shopping/dspsd.gif', name: 'Bp de SD', description: 'Uma backpack contendo 20 runas de Sudden Death, com 20x de carga em cada runa.', price: "20 DSP's", category: 'runas' },
    ];

    premium: ShopItem[] = [
        { img: 'assets/shopping/dsppremy.gif', name: 'Account Premium (30 dias)', description: '30 dias de Account premium, podendo acessar lugares, promoções, entre outras coisas onde somente premmys podem utilizar.', price: "100 DSP's", category: 'premium' },
    ];

    items: ShopItem[] = [
        { img: 'assets/shopping/dsplr.gif', name: 'Life Ring', description: 'Uma backpack de life ring.', price: "10 DSP's", category: 'items' },
        { img: 'assets/shopping/dsproh.gif', name: 'Ring of Healing', description: 'Uma backpack de Ring of Healing.', price: "20 DSP's", category: 'items' },
        { img: 'assets/shopping/dspmana.gif', name: 'Large Mana Fluid', description: 'Mana Fluid uso 100x, recupera 5% + 300 da mana total, delay 1 segundo. (pode ser usada em Hotkey)', price: "15 DSP's", category: 'items' },
        { img: 'assets/shopping/dspbr.gif', name: 'Blessed Ring', description: 'Uma bp de blessed ring que quando colocado no dedo adiciona: 10% de Absorve em todos ataques, 10% Adicional de Magic Power, Regen de hp 1 de hp a cada 5 sec, Regen de mana 1 mana a cada 5 sec, +5 em todos skills, +3 defense, duração do ring 30 minutos.', price: "40 DSP's", category: 'items' },
        { img: 'assets/shopping/dspeoe1.gif', name: 'Small Elixir of Experience', description: '50 Small Elixir of Experience, que acrescenta experiencia dependendo do Level + Magic Level + Fist, contendo 5% de chance de bônus de HP e Mana equivalente a 1 level a cada uso (Bônus máximo: 10), consumindo 250 souls a cada uso.', price: "30 DSP's", category: 'items' },
        { img: 'assets/shopping/dspeoe2.gif', name: 'Normal Elixir of Experience', description: '50 Normal Elixir of Experience, que acrescenta experiencia dependendo do Level + Magic Level + Fist, contendo 5% de chance de bônus de HP e Mana equivalente a 2 leveis a cada uso (Bônus máximo: 10), consumindo 250 souls a cada uso (Para level superior a 150).', price: "50 DSP's", category: 'items' },
        { img: 'assets/shopping/dsptp.gif', name: 'Teleport', description: '10 Teleports, item utilizado para se teleportar de uma cidade a outra usando os comandos !carlin, !edron, !tirith, !raccoon e !bree, usando 1 teleport a cada uso (Utilizado somente em PZ). Podendo também salvar um devido local.', price: "25 DSP's", category: 'items' },
        { img: 'assets/shopping/dspfs.gif', name: 'Fighting Spirit', description: '1 Fighting Spirit, item utilizado para duplicar a experiencia obtida de criaturas, tem duração de 30 minutos e é utilizado no slot ring. Obs: Item some assim que tirado do slot ring.', price: "50 DSP's", category: 'items' },
        { img: 'assets/shopping/dspen.png', name: 'Energético', description: '1 Energético, item utilizado para recuperação de stamina, proporciona 10 minutos de uma forte recuperação.', price: "20 DSP's", category: 'items' },
        { img: 'assets/shopping/dspbl.png', name: "Blood of God's", description: "1 Backpack com 20 Blood of God's, item utilizado para metamorfose, podendo ser invocado Chronos, Kazard ou Hazus, ganhando atributos únicos, regenera a cada 2 segundos (First + Magic Level + 10%) de Mana e HP total. Sua duração é de 30 segundos e utiliza 50 Souls Points.", price: "50 DSP's", category: 'items' },
    ];

    variados: ShopItem[] = [
        { img: 'assets/shopping/dspsex.gif', name: 'Cirurgia', description: 'Permite que você troque de sexo (Male/Female).', price: "100 GP's", category: 'variados' },
    ];
} 