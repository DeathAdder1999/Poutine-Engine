This is the core part of the Poutine-Engine.

Main entity of the Engine is GameObject. Which is assigned a unique ReferenceID in order to be differentiated and saved.
Scene class is the root of all of the objects, GameObjects are updated in tree structure where the root is the loaded Scene.

GameObjectManager contains all of the gameobjects currently present in the scene. Notifies all of the managers when object is added or removed.

Main Game loop:

Handle Input
Check Collisions
Logic Update (includes script updates)
Render

The engine uses component system. Current Supported components:

InputComponent:
  Contains a queue of actions corresponding to inputs, to be handled at a next Update()
  
PhysicsComponent:
  Is necessary for the collision detection and the movement
  
Collider Component:
  Has a shape associated with each type of component (i.e. RectangleCollider, CircleCollider etc.)
  
RenderComponent:
  Each gameobject which has any kind of graphical representation must have this component attached to it
  
  
The Poutine Engine is scriptable, which means that the user can add scripts to gameobjects which use GameScript, in order to manipulate/change gameobject behaviour
