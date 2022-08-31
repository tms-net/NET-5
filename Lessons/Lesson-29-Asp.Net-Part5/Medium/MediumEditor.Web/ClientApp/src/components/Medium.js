import React, { Component } from 'react';
import { Form, FormGroup, Input, Button, Label, Col, Alert } from 'reactstrap';

export class Medium extends Component {
  static displayName = Medium.name;

  constructor(props) {
    super(props);
      this.state = {
        title: '',
        text: '',
        isSent: false,
        isError: false
      };
      this.handleTitleChange = this.handleTitleChange.bind(this);
      this.handleTextChange = this.handleTextChange.bind(this);
      this.handleSubmit = this.handleSubmit.bind(this);
  }

  handleTitleChange(e) {
    this.setState({
      title: e.target.value
    });
  }

  handleTextChange(e) {
    this.setState({
      text: e.target.value
    });
  }

  handleSubmit(e) {
    e.preventDefault();

    fetch('/new-post')
      .then(response => {
        this.setState({
          title: '',
          text: '',
          isSent: true,
          isError: false
        });
      })
      .catch(response => {
        this.setState({
          isError: true,
          isSent: false
        });
      })

    console.log(this.state);
  }

  render() {
    return (
      <div>

        <Alert isOpen={this.state.isSent}>
          Спасибо, статья отправлена!
        </Alert>
        
        <Alert isOpen={this.state.isError} color="danger">
          Произошла ошибка!
        </Alert>

        <Form onSubmit={this.handleSubmit}>
          <FormGroup row className='mb-3'>
            <Label for="title" sm={2}>
              Заголовок
            </Label>
            <Col sm={10}>
              <Input
                id="title"
                name="title"
                type="text"
                value={this.state.title}
                onChange={this.handleTitleChange}
              />
            </Col>
          </FormGroup>
          {' '}
          <FormGroup row className='mb-3'>
            <Label for="text" sm={2}>
              Текст
            </Label>
            <Col sm={10}>
              <Input
                id="text"
                name="text"
                type="textarea"
                value={this.state.text}
                onChange={this.handleTextChange} />
            </Col>
          </FormGroup>          
          {' '}
          <FormGroup row className='mb-3'>
            <Label for="file" sm={2}>
              Изображение
            </Label>
            <Col sm={10}>
              <Input
                id="file"
                name="file"
                type="file"
              />
            </Col>
          </FormGroup>          
          {' '}
          <Button>
            Создать
          </Button>
          {/* <div>
            {this.state.title}
          </div>
          <div>
            {this.state.text}
          </div> */}
        </Form>
      </div>
    );
  }
}
