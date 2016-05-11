# MajorUrsaAndTheSalmonAramada-StoreScripts
Epic SHMUP (Shoot Em Up) adventure game! 

The store in our game is supposed to offer the player a variety of items to sell.
With my implementation, I aimed to make it as modular as possible so it would be extremely easy to add more items to it. 

I allow the players to 'Try' a design before they decide to buy it. If they try it, through the Preview script I show them how it would look like on their character using visual feedback.
If they decide to buy it, a simple check reassures that was what the player intended to do. Once the player buys the hat, that money is dedacted from their score. I calculate the score based on the type of enemy the player kills and add onto it for each player kill.

The shopkeeper says something everytime the store is opened, closed or when the player tries/buys a new item. Each of these are unique to the corresponding action.
