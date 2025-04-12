import React, { useEffect, useState } from 'react';
import {
  Dialog,
  DialogTitle,
  DialogContent,
  DialogActions,
  TextField,
  Button,
  FormControl,
  InputLabel,
  Select,
  MenuItem,
} from '@mui/material';
import api from '../services/api';

const UsuarioDialog = ({
  open,
  handleClose,
  handleSubmit,
  handleChange,
  formData,
  editMode,
}) => {
  const [departamentos, setDepartamentos] = useState([]);
  const [cargos, setCargos] = useState([]);
  const [loadingDepartamentos, setLoadingDepartamentos] = useState(true);
  const [loadingCargos, setLoadingCargos] = useState(true);
  const [errorDepartamentos, setErrorDepartamentos] = useState(null);
  const [errorCargos, setErrorCargos] = useState(null);

  // Fetch Departamentos
  useEffect(() => {
    api.get('/admin/departamentos')
      .then(res => {
        setDepartamentos(res.data);
        setLoadingDepartamentos(false);
      })
      .catch(err => {
        console.error(err);
        setErrorDepartamentos('Error al cargar los departamentos');
        setLoadingDepartamentos(false);
      });
  }, []);

  // Fetch Cargos
  useEffect(() => {
    api.get('/admin/cargos')
      .then(res => {
        setCargos(res.data);
        setLoadingCargos(false);
      })
      .catch(err => {
        console.error(err);
        setErrorCargos('Error al cargar los cargos');
        setLoadingCargos(false);
      });
  }, []);

  return (
    <Dialog open={open} onClose={handleClose} fullWidth>
      <DialogTitle>{editMode ? 'Editar Usuario' : 'Agregar Usuario'}</DialogTitle>
      <DialogContent>
        <TextField
          label="Usuario"
          name="usuario"
          fullWidth
          margin="dense"
          value={formData.usuario}
          onChange={handleChange}
        />
        <TextField
          label="Primer Nombre"
          name="primerNombre"
          fullWidth
          margin="dense"
          value={formData.primerNombre}
          onChange={handleChange}
        />
        <TextField
            label="Segundo Nombre"
            name="segundoNombre"
            fullWidth
            margin="dense"
            value={formData.segundoNombre}
            onChange={handleChange}
        />
        <TextField
          label="Primer Apellido"
          name="primerApellido"
          fullWidth
          margin="dense"
          value={formData.primerApellido}
          onChange={handleChange}
        />
        <TextField
            label="Segundo Apellido"
            name="segundoApellido"
            fullWidth
            margin="dense"
            value={formData.segundoApellido}
            onChange={handleChange}
        />
        <FormControl fullWidth margin="dense">
          <InputLabel>Departamento</InputLabel>
          <Select
            name="idDepartamento"
            value={formData.idDepartamento}
            onChange={handleChange}
            label="Departamento"
          >
            {loadingDepartamentos ? (
              <MenuItem disabled>Cargando departamentos...</MenuItem>
            ) : errorDepartamentos ? (
              <MenuItem disabled>{errorDepartamentos}</MenuItem>
            ) : (
              departamentos.map((dep) => (
                <MenuItem key={dep.id} value={dep.id}>
                  {dep.nombre}
                </MenuItem>
              ))
            )}
          </Select>
        </FormControl>

        <FormControl fullWidth margin="dense">
          <InputLabel>Cargo</InputLabel>
          <Select
            name="idCargo"
            value={formData.idCargo}
            onChange={handleChange}
            label="Cargo"
          >
            {loadingCargos ? (
              <MenuItem disabled>Cargando cargos...</MenuItem>
            ) : errorCargos ? (
              <MenuItem disabled>{errorCargos}</MenuItem>
            ) : (
              cargos.map((cargo) => (
                <MenuItem key={cargo.id} value={cargo.id}>
                  {cargo.nombre}
                </MenuItem>
              ))
            )}
          </Select>
        </FormControl>
      </DialogContent>
      <DialogActions>
        <Button onClick={handleClose}>Cancelar</Button>
        <Button variant="contained" onClick={handleSubmit} color="primary">
          {editMode ? 'Guardar Cambios' : 'Agregar'}
        </Button>
      </DialogActions>
    </Dialog>
  );
};

export default UsuarioDialog;

