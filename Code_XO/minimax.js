
function bestMove() {
  // AI to make its turn
  let bestScore = -Infinity; // điêmr tốt nhất à âm vô cực 
  let move; // Tạo ra 1 biến tuyên bố nước đi tốt nhất
  for (let i = 0; i < 3; i++) {
    for (let j = 0; j < 3; j++) {
      // Có chỗ trống không? rồi cho ai đi trước
      if (board[i][j] == '') {
        board[i][j] = ai;
        // sau khi AI đi tạo một biến để đi bước tiếp
        let score = minimax(board, 0, false);
        board[i][j] = '';
        if (score > bestScore) { // Kiểm tra điểm lớn hơn điểm tốt nhất
          bestScore = score;
          move = { i, j };
        }
      }
    }
  }
  board[move.i][move.j] = ai;
  currentPlayer = human;
}

let scores = {
  X: 10,
  O: -10,
  tie: 0
};
// depth : độ sâu
// isMaximizing = tượng tượng trưng cho x 
function minimax(board, depth, isMaximizing) {
  let result = checkWinner();
  if (result !== null) {
    return scores[result];
  }

  if (isMaximizing) {
    let bestScore = -Infinity;
    for (let i = 0; i < 3; i++) {
      for (let j = 0; j < 3; j++) {
        // Kiểm tra còn trỗ trống 
        if (board[i][j] == '') {
          board[i][j] = ai;
          let score = minimax(board, depth + 1, false);
          board[i][j] = '';
          bestScore = max(score, bestScore);
        }
      }
    }
    return bestScore;
  } else {
    let bestScore = Infinity;
    for (let i = 0; i < 3; i++) {
      for (let j = 0; j < 3; j++) {
        // Kiểm tra còn trỗ trống 
        if (board[i][j] == '') {
          board[i][j] = human;
          let score = minimax(board, depth + 1, true);
          board[i][j] = '';
          bestScore = min(score, bestScore);
        }
      }
    }
    return bestScore;
  }
}
