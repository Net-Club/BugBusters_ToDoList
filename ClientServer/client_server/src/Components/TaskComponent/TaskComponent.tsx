import React from 'react';


function TasksComponent() {
  return (
    <h1 onClick={Click}>Tasks</h1>
  );
}

function Click()
{
  console.log(localStorage.getItem("token"))
}

export default TasksComponent;