const apiUrl = 'https://localhost:7073/api';

async function cargarClientes() {
  const res = await fetch('https://localhost:7073/api/Client');
  const data = await res.json();
  const ul = document.getElementById('listaClientes');
  ul.innerHTML = '';
  data.forEach(c => {
    const li = document.createElement('li');
    li.textContent = `${c.clienteId} – ${c.nombre} (${c.cedula})`;
    li.className = 'list-group-item';
    ul.appendChild(li);
  });
}

async function crearCliente(evt) {
  evt.preventDefault();
  const cliente = {
    nombre: document.getElementById('nombreCliente').value,
    cedula: document.getElementById('cedulaCliente').value,
    email: document.getElementById('emailCliente').value
  };

  const res = await fetch('https://localhost:7073/api/Client', {
    method: 'POST',
    headers: { 'Content-Type': 'application/json' },
    body: JSON.stringify(cliente)
  });

  const alerta = document.getElementById('alerta');
  if (res.ok) {
    alerta.textContent = '✅ Cliente creado correctamente';
    alerta.classList.replace('alert-info','alert-success');
    alerta.classList.remove('d-none');
    cargarClientes();
    document.getElementById('formCliente').reset();
  } else {
    alerta.textContent = '❌ Error al crear cliente';
    alerta.classList.replace('alert-info','alert-danger');
    alerta.classList.remove('d-none');
  }
}

document.getElementById('btnCargarClientes').addEventListener('click', cargarClientes);
document.getElementById('formCliente').addEventListener('submit', crearCliente);
