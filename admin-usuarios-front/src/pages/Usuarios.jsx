import React, { useEffect, useState } from 'react';
import api from '../services/api';
import {
  Container, Typography, Button, Dialog, DialogActions, DialogContent,
  DialogTitle, TextField, Stack
} from '@mui/material';
import { DataGrid } from '@mui/x-data-grid';
import {
  Edit as EditIcon,
  Delete as DeleteIcon,
  Add as AddIcon,
  ReplyOutlined
} from '@mui/icons-material';
import UsuarioDialog from '../components/dialogo'; // ajusta la ruta si está en otro subdirectorio


const Usuarios = () => {
  const [usuarios, setUsuarios] = useState([]);
  const [open, setOpen] = useState(false);
  const [editMode, setEditMode] = useState(false);
  const [formData, setFormData] = useState({
    usuario: '', primerNombre: '', primerApellido: '', idDepartamento: '', idCargo: ''
  });
  const [selectedId, setSelectedId] = useState(null);



  const fetchUsuarios = async () => {
    try {
      const res = await api.get('/admin/usuarios');
      setUsuarios(res.data);
    } catch (err) {
      console.error('Error fetching usuarios:', err);
    }
  };
  

  useEffect(() => {
    fetchUsuarios();
  }, []);

  const handleOpen = (usuario = null) => {
    console.log(usuario)
    if (usuario) {
      setEditMode(true);
      setFormData(usuario);
      setSelectedId(usuario.id);
    } else {
      setEditMode(false);
      setFormData({ usuario: '', primerNombre: '', primerApellido: '', idDepartamento: '', idCargo: '' });
      setSelectedId(null);
    }
    setOpen(true);
  };

  const handleClose = () => setOpen(false);

  const handleChange = e => {
    setFormData({ ...formData, [e.target.name]: e.target.value });
  };

  const handleSubmit = () => {
    // Asegúrate de que los datos coincidan con el formato del backend
    const requestData = {
      usuario: formData.usuario,
      PrimerNombre: formData.primerNombre,
      SegundoNombre: formData.segundoNombre,
      PrimerApellido: formData.primerApellido,
      SegundoApellido: formData.segundoApellido,

      IdDepartamento: formData.idDepartamento,
      IdCargo: formData.idCargo
    };
    console.log(requestData)
    const request = editMode
      ? api.put(`/admin/usuarios/${selectedId}`, requestData)
      : api.post('/admin/usuarios', requestData);
  
    request.then(() => {
      fetchUsuarios();
      handleClose();
    }).catch(err => console.error(err));
  };
  

  const handleDelete = (id) => {
    if (window.confirm('¿Estás seguro de eliminar este usuario?')) {
      api.delete(`/admin/usuarios/${id}`)
        .then(() => fetchUsuarios())
        .catch(err => console.error(err));
    }
  };

  const columns = [
    { field: 'usuario', headerName: 'Usuario', flex: 1 },
    { field: 'primerNombre', headerName: 'Nombre', flex: 1 },
    { field: 'primerApellido', headerName: 'Apellido', flex: 1 },
    {
      field: 'departamento',
      headerName: 'Departamento',
      valueGetter: (params) => {
        
        return params.nombre;
      },
      flex: 1,
    },
    {
      field: 'cargo',
      headerName: 'Cargo',
      valueGetter: (params) => (params.nombre),
      flex: 1,
    },
    {
      field: 'acciones',
      headerName: 'Acciones',
      sortable: false,
      renderCell: (params) => (
        <Stack direction="row" spacing={1}>
          <Button
            onClick={() => handleOpen(params.row)}
            startIcon={<EditIcon />}
            variant="outlined"
            color="primary"
            size="small"
          >
            Editar
          </Button>
          <Button
            onClick={() => handleDelete(params.row.id)}
            startIcon={<DeleteIcon />}
            variant="outlined"
            color="error"
            size="small"
          >
            Eliminar
          </Button>
        </Stack>
      ),
      flex: 1.5,
    },
  ];

  return (
    <Container>
      <Stack direction="row" justifyContent="space-between" alignItems="center" sx={{ my: 3 }}>
        <Typography variant="h4">Usuarios</Typography>
        <Button
          variant="contained"
          color="success"
          startIcon={<AddIcon />}
          onClick={() => handleOpen()}
        >
          Agregar Usuario
        </Button>
      </Stack>

      <div style={{ height: 500, width: '100%' }}>
        <DataGrid
          rows={usuarios}
          columns={columns}
          pageSize={10}
          rowsPerPageOptions={[10, 20]}
          getRowId={(row) => row.id}
        />
      </div>

      <UsuarioDialog
        open={open}
        handleClose={handleClose}
        handleChange={handleChange}
        handleSubmit={handleSubmit}
        formData={formData}
        editMode={editMode}
       
      />

      
    </Container>
  );
};

export default Usuarios;
