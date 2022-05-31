# CapStone - Genex
  Genx is a group capstone project, it is a first person, exploration, creation game. Where the player explores a planet, finds new species of local animal life, collects there DNA strands which contains body parts and there behavior. You can then combine the DNA strands to create a new randomly generated creature that has never been seen before. The main mechanic I worked on was to handle the creation of the new creatures including everything, from the original population of the world to the splicing and creation of new creatures as well as a majority of the level design, graphic pipeline and some other features like the log book display and the display capsule in the lab.
 Details:
* Creatures contain a DNA struct of information the contains everything to do with how the creature was created and how it should act.
* Creatures are created by a method of dominant and recessive trait system.
  * If a component is currently displayed on the creatures body it is a dominant trait and has a much greater chance of appear in the newly created species of creatures the player creates.
  * A recessive trait is anything that is not currently being displayed
* Designed a camera cinematic to show the new creature being created.
* Creatures need to be spawned from towers around the map.
* When you find a new creature and scan its DNA there is a log so you can see all creatures you have scanned in all its angles.
* Creatures body and components animation loops synchronized even after generation.
