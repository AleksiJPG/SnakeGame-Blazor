export function drawGame(canvas, snake, food, width, height, isGameOver) {
    const ctx = canvas.getContext("2d");
    const cellSize = canvas.width / width;

    // Clear
    ctx.fillStyle = "white";
    ctx.fillRect(0, 0, canvas.width, canvas.height);

    // Snake
    ctx.fillStyle = "green";
    snake.forEach(p => {
        ctx.fillRect(p.x * cellSize, p.y * cellSize, cellSize, cellSize);
    });

    // Food
    ctx.fillStyle = "red";
    ctx.fillRect(food.x * cellSize, food.y * cellSize, cellSize, cellSize);

    if (isGameOver) {
        ctx.fillStyle = "rgba(0, 0, 0, 0.5)";
        ctx.fillRect(0, 0, canvas.width, canvas.height);

        ctx.fillStyle = "white";
        ctx.font = "40px Arial";
        ctx.textAlign = "center";
        ctx.fillText("GAME OVER", canvas.width / 2, canvas.height / 2);

        //Score overlay
        ctx.font = "25px Arial";
        ctx.fillText("Score: " + (snake.length - 1), canvas.width / 2, canvas.height / 2 + 50);
    }
}

// Fokus canvas elementtiin
export function focusCanvas(canvas) {
    canvas.focus();
}