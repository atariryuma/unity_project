import pygame
import random

# Constants
WINDOW_WIDTH = 640
WINDOW_HEIGHT = 480
CELL_SIZE = 20

# Colors
BLACK = (0, 0, 0)
WHITE = (255, 255, 255)
GREEN = (0, 255, 0)
RED = (255, 0, 0)

pygame.init()

screen = pygame.display.set_mode((WINDOW_WIDTH, WINDOW_HEIGHT))
pygame.display.set_caption('Snake Game')
clock = pygame.time.Clock()

font = pygame.font.SysFont('arial', 24)

def draw_text(text, pos, color=WHITE):
    text_surface = font.render(text, True, color)
    screen.blit(text_surface, pos)

class Snake:
    def __init__(self):
        self.segments = [(WINDOW_WIDTH // 2, WINDOW_HEIGHT // 2)]
        self.direction = (0, -CELL_SIZE)

    def move(self):
        head_x, head_y = self.segments[0]
        delta_x, delta_y = self.direction
        new_head = ((head_x + delta_x) % WINDOW_WIDTH, (head_y + delta_y) % WINDOW_HEIGHT)
        self.segments = [new_head] + self.segments[:-1]

    def grow(self):
        tail = self.segments[-1]
        self.segments.append(tail)

    def change_direction(self, new_direction):
        opposite = (-self.direction[0], -self.direction[1])
        if new_direction != opposite:
            self.direction = new_direction

    def collide(self):
        return self.segments[0] in self.segments[1:]

    def draw(self):
        for segment in self.segments:
            rect = pygame.Rect(segment[0], segment[1], CELL_SIZE, CELL_SIZE)
            pygame.draw.rect(screen, GREEN, rect)

class Food:
    def __init__(self):
        self.position = self.random_position()

    def random_position(self):
        cols = WINDOW_WIDTH // CELL_SIZE
        rows = WINDOW_HEIGHT // CELL_SIZE
        return (random.randint(0, cols - 1) * CELL_SIZE,
                random.randint(0, rows - 1) * CELL_SIZE)

    def respawn(self):
        self.position = self.random_position()

    def draw(self):
        rect = pygame.Rect(self.position[0], self.position[1], CELL_SIZE, CELL_SIZE)
        pygame.draw.rect(screen, RED, rect)


def main():
    snake = Snake()
    food = Food()
    score = 0
    running = True

    while running:
        for event in pygame.event.get():
            if event.type == pygame.QUIT:
                running = False
            elif event.type == pygame.KEYDOWN:
                if event.key == pygame.K_UP:
                    snake.change_direction((0, -CELL_SIZE))
                elif event.key == pygame.K_DOWN:
                    snake.change_direction((0, CELL_SIZE))
                elif event.key == pygame.K_LEFT:
                    snake.change_direction((-CELL_SIZE, 0))
                elif event.key == pygame.K_RIGHT:
                    snake.change_direction((CELL_SIZE, 0))

        snake.move()

        if snake.segments[0] == food.position:
            snake.grow()
            food.respawn()
            score += 1

        if snake.collide():
            running = False

        screen.fill(BLACK)
        snake.draw()
        food.draw()
        draw_text(f'Score: {score}', (10, 10))
        pygame.display.flip()
        clock.tick(10)

    pygame.quit()

if __name__ == '__main__':
    main()
