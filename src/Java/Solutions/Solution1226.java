package solutions;

import structures.TreeNode;

public class Solution1226 {
    /**
     * 1226. The Dining Philosophers - Medium
     * @see https://leetcode.com/problems/the-dining-philosophers
     */
    // One fork between each pair of philosophers
    private final Semaphore[] forks = new Semaphore[5];

    // Butler limits max philosophers eating at the same time to 4
    private final Semaphore butler = new Semaphore(4); // Prevents deadlock

    public DiningPhilosophers() {
        for (int i = 0; i < 5; i++) {
            forks[i] = new Semaphore(1); // Each fork is initially available
        }
    }

    public void wantsToEat(
        int philosopher,
        Runnable pickLeftFork,
        Runnable pickRightFork,
        Runnable eat,
        Runnable putLeftFork,
        Runnable putRightFork
    ) throws InterruptedException {

        int left = philosopher;
        int right = (philosopher + 1) % 5;

        butler.acquire();             // Enter the dining room
        forks[left].acquire();        // Pick left fork
        forks[right].acquire();       // Pick right fork

        pickLeftFork.run();
        pickRightFork.run();

        eat.run();

        putLeftFork.run();
        putRightFork.run();

        forks[left].release();        // Put down left fork
        forks[right].release();       // Put down right fork
        butler.release();             // Leave the dining room
    }
}
