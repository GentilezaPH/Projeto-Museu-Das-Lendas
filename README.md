# 🎮 Projeto-Museu-Das-Lendas (Ainda não foi decidido o nome final do game)

> 🚧 **Status do Projeto:** Em desenvolvimento *(núcleo da gameplay, arquitetura base e sistemas principais implementados)*

## 💡 Sobre o Projeto
Projeto autoral de jogo desenvolvido em **C#** na engine **Unity**, focado na investigação, rastreamento de evidências e captura de criaturas. O objetivo técnico do projeto é aplicar conceitos sólidos de **Programação Orientada a Objetos (POO)**, arquitetura modular, programação orientada a dados e sincronização de estado em rede.

---

## 🏗️ Arquitetura e Sistemas Implementados
O código foi estruturado de forma modular para facilitar a manutenção e a escalabilidade das mecânicas:

- **Core & Sessão (`Core/`):** Gerenciamento do ciclo de vida do jogo e controle de sessões (`GameManager`, `SessionManager`).
- **Inteligência e Controle de Criaturas (`CreaturesControl/` & `DataCreatures/`):** Implementação baseada em **herança** (`CreatureController` estendido por controladores específicos de cada criatura) e **ScriptableObjects** (`CreatureData`) para desacoplar dados de comportamento.
- **Sistemas do Jogador e Equipamentos (`Player/` & `Equipment/`):** Movimentação via *Unity Input System*, sistema de inventário (`PlayerInventory`), rastreamento de pistas (`EvidenceTracker`, `EvidenceTool`) e estrutura base para armadilhas (`TrapBase`).
- **Progressão e Estados (`Museum/` & `Enums/`):** Controle de progresso de descobertas (`MuseumProgress`) e máquinas de estado tipadas via enums (`CreatureState`, `EvidenceType`, `TrapType`).
- **Suporte Multiplayer (`Networking/`):** Estrutura inicial para gerenciamento de partidas e sincronização de entidades em rede (`NetworkGameManager`, `NetworkCreatureSync`).

---

## 🗺️ Próximos Passos
- [ ] Expansão das mecânicas de comportamento e IA de cada criatura.
- [ ] Refinamento da sincronização multiplayer e testes de sessão.
- [ ] Implementação de interface de usuário (HUD, inventário visual e menus).
- [ ] Polimento visual (URP), efeitos sonoros e balanceamento de gameplay.

---

## 🛠️ Tecnologias Utilizadas
- **Linguagem:** C#
- **Engine & Recursos:** Unity (Universal Render Pipeline - URP, New Input System)
- **Conceitos Aplicados:** Programação Orientada a Objetos (Herança, Encapsulamento, Polimorfismo), ScriptableObjects, Máquinas de Estado e Networking.
- **Versionamento:** Git & GitHub

---

## 👨‍💻 Autor
Desenvolvido por **Pedro Gentil** — Estudante de Engenharia da Computação (UEMG), **Eduardo Garcia** - Estudante de Ciência da Computação (UNIP), **Gabriel Monteiro** - Estudante de Engenharia da Computação (UNAERP)
[LinkedIn](https://linkedin.com/in/gentilpedro) | [GitHub](https://github.com/GentilezaPH)
